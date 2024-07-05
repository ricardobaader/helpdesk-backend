using API.DTOs.Requests;
using Common.Application.Services.Email;
using Common.Domain;
using Common.Domain.Rooms;
using Common.Domain.TicketImages;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Exceptions;
using Common.Utils.Extensions;
using InvalidDataException = Common.Exceptions.InvalidDataException;

namespace Common.Application.Services.Tickets
{
    internal class TicketsService : ITicketsService
    {
        private const int MaxImageSizeInBytes = 5 * 1024 * 1024; // 5 MB

        private readonly string FrontendBaseUrl = Environment.GetEnvironmentVariable("FRONTEND_BASE_URL");
        private readonly List<string> AcceptedImageContentTypes = new() { "image/jpg", "image/png", "image/jpeg", "image/webp" };

        private readonly ITicketsRepository _ticketsRepository;
        private readonly IBaseEntityRepository<User> _usersRepository;
        private readonly IBaseEntityRepository<Room> _roomsRepository;
        private readonly IBaseEntityRepository<TicketImage> _ticketImagesRepository;
        private readonly IEmailSenderService _emailSenderService;

        public TicketsService(ITicketsRepository ticketRepository,
            IBaseEntityRepository<User> usersRepository,
            IBaseEntityRepository<Room> roomsRepository,
            IEmailSenderService emailSenderService,
            IBaseEntityRepository<TicketImage> ticketImagesRepository)
        {
            _ticketsRepository = ticketRepository;
            _usersRepository = usersRepository;
            _roomsRepository = roomsRepository;
            _emailSenderService = emailSenderService;
            _ticketImagesRepository = ticketImagesRepository;
        }

        public async Task<Guid> Create(CreateTicketDto request)
        {
            var roomId = await _roomsRepository.ProjectOneBy(x => x.Id, x => x.Id == request.RoomId && !x.IsDeleted);
            if (roomId == Guid.Empty)
                throw new EntityNotFoundException("A sala informada não existe");

            var user = await _usersRepository.SelectOneBy(x => x.Id == request.UserId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            var ticket = TicketMapper.MapCreateTicketDtoToTicket(request);
            if (ticket.IsValid == false)
                throw new InvalidDataException($"Não foi possível criar um chamado porque existem incoerências nos dados Errors: {string.Join("; ", ticket.Errors)}");

            var ticketImages = new List<TicketImage>();

            foreach (var image in request.Images)
            {
                if (!AcceptedImageContentTypes.Contains(image.ContentType))
                    throw new InvalidDataException($"Tipo de extensão de imagem não suportado: {image.ContentType}. Tipos aceitos: {string.Join(", ", AcceptedImageContentTypes)}");

                if (image.Length > MaxImageSizeInBytes)
                    throw new InvalidDataException("A imagem excede o tamanho máximo permitido de 5 MB.");

                var imageBytes = await image.ConvertToByteArray();

                ticketImages.Add(new TicketImage(ticket.Id, imageBytes));
            }

            await _ticketsRepository.InsertOne(ticket);
            await _ticketImagesRepository.InsertMany(ticketImages);

            var subject = "Chamado criado com Sucesso!";
            var message = @$"
                <p>Olá {user.Name},</p>
                <p>Seu chamado <b>{ticket.Title}</b> foi criado com sucesso e já está na fila para ser atendido.</p>
                <p>Se necessário, entraremos em contato para obter mais informações sobre o problema.</p>
                <p>Para acompanhar o status do chamado, clique no botão abaixo:</p>
                <p><a href='{FrontendBaseUrl}/dashboard/user/tickets/{ticket.Id}' class='btn'>Clique Aqui</a></p>
                <p>Obrigado por contribuir para a melhoria de nossa Universidade.</p>";

            await _emailSenderService.SendEmailAsync(user.Email, subject, message);

            return ticket.Id;
        }

        public async Task<IEnumerable<ListTicketsDto>> ListAllBy(Guid userId, TicketsFiltersRequest request)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            var filters = request.ToTicketsFiltersDto();

            if (user.UserType == UserType.User)
                return await _ticketsRepository.ListAllTicketsBy(userId, filters);

            return await _ticketsRepository.ProjectManyBy(x => new ListTicketsDto
            {
                Id = x.Id,
                Number = x.Number,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Description = x.Room.Description,
                }
            }, x => !request.Status.HasValue || x.Status == request.Status);
        }

        public async Task<IEnumerable<ListTicketsDto>> ListAllTicketsTakedBy(Guid supporUserId)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == supporUserId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            return await _ticketsRepository.ProjectManyBy(x => new ListTicketsDto
            {
                Id = x.Id,
                Number = x.Number,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Description = x.Room.Description,
                }
            }, x => x.SupportUserId == supporUserId);
        }

        public async Task<ListTicketsDto> ListById(Guid ticketId)
        {
            return await _ticketsRepository.ProjectOneBy(x => new ListTicketsDto
            {
                Id = x.Id,
                Title = x.Title,
                Number = x.Number,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.User.Name,
                Attendant = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Description = x.Room.Description
                },
                Images = x.TicketImages.Select(x => x.Image).ToList()
            }, x => x.Id == ticketId);
        }

        public async Task Start(Guid id, Guid supportUserId)
        {
            var ticket = await ValidateIfTicketCanChangeStatus(id, supportUserId);

            ticket.StartTicket(supportUserId);

            _ticketsRepository.UpdateOne(ticket);

            var user = await _usersRepository.SelectOneBy(x => x.Id == ticket.UserId);

            await SendTicketStatusUpdateEmailAsync(ticket, user);
        }

        public async Task Finish(Guid id, Guid supportUserId)
        {
            var ticket = await ValidateIfTicketCanChangeStatus(id, supportUserId);

            if (ticket.Status != TicketStatus.InProgress)
                throw new InvalidDataException("Somente chamados em progresso podem ser resolvido");

            ticket.FinishTicket();

            _ticketsRepository.UpdateOne(ticket);

            var user = await _usersRepository.SelectOneBy(x => x.Id == ticket.UserId);

            await SendTicketStatusUpdateEmailAsync(ticket, user);
        }

        public async Task Close(Guid id, Guid userId)
        {
            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (ticket is null)
                throw new EntityNotFoundException("O chamado informado não existe");

            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            if (user.UserType != UserType.User)
                throw new InvalidDataException("Somente um funcionário da equipe de suporte pode alterar um chamado");

            if (ticket.Status != TicketStatus.Solved)
                throw new InvalidDataException("Somente chamados resolvidos podem ser encerrados");

            var deletedTicketImages = new List<TicketImage>();

            foreach (var ticketImage in ticket.TicketImages)
            {
                ticketImage.SetDelete();
                deletedTicketImages.Add(ticketImage);
            }

            ticket.CloseTicket();

            _ticketsRepository.UpdateOne(ticket);
            _ticketImagesRepository.UpdateMany(deletedTicketImages);

            await SendTicketStatusUpdateEmailAsync(ticket, user);
        }

        public async Task Cancel(Guid id, Guid userId)
        {
            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (ticket is null)
                throw new EntityNotFoundException("O chamado informado não existe");

            if (ticket.UserId != userId)
                throw new InvalidDataException("Apenas o usuário que criou o chamado pode excluí-lo.");

            if (ticket.Status != TicketStatus.Pending)
                throw new InvalidDataException("Um chamado em andamento ou concluído não pode ser excluído");

            ticket.CancelTicket();

            _ticketsRepository.UpdateOne(ticket);
        }

        private async Task<Ticket> ValidateIfTicketCanChangeStatus(Guid id, Guid supportUserId)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == supportUserId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            if (user.UserType != UserType.Employee)
                throw new InvalidDataException("Somente um funcionário da equipe de suporte pode alterar um chamado");

            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (ticket is null)
                throw new EntityNotFoundException("O chamado informado não existe");

            return ticket;
        }

        private async Task SendTicketStatusUpdateEmailAsync(Ticket ticket, User user)
        {
            var subject = $"Status do Chamado {ticket.Number} foi Atualizado!";
            var message = @$"
                <p>Olá {user.Name},</p>
                <p>O status do seu chamado foi atualizado.</p>
                <p><b>Novo Status: </b>{ticket.Status.GetDescription()}</p>
                <p>Para acompanhar o seu chamado, aperte o botão abaixo:</p>
                <p><a href='{FrontendBaseUrl}/dashboard/user/tickets/{ticket.Id}' class='btn'>Clique Aqui</a></p>
                <p>Estamos à disposição para qualquer dúvida!</p>";

            await _emailSenderService.SendEmailAsync(user.Email, subject, message);
        }
    }
}
