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

        public async Task Create(CreateTicketDto request)
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
                var imageBytes = await image.ConvertToByteArray();

                ticketImages.Add(new TicketImage(ticket.Id, imageBytes));
            }

            await _ticketsRepository.InsertOne(ticket);
            await _ticketImagesRepository.InsertMany(ticketImages);

            var subject = "Chamado criado com Sucesso!";
            var message = @$"
                <p>Olá {user.Name},</p>
                <p>Seu chamado foi criado com sucesso e recebido por nosso sistema e está na fila para ser atendido.</p>
                <p>Caso necessário, entraremos em contato para obter mais informações a respeito do problema.</p>
                <p>Para acompanhar o status do chamado, aperte o botão abaixo:</p>
                <p><a href='#' class='btn'>Clique Aqui</a></p>
                <p>Obrigado por contribuir pela melhoria de nossa Universidade.</p>";

            await _emailSenderService.SendEmailAsync(user.Email, subject, message);
        }

        public async Task<IEnumerable<ListTicketsDto>> ListAllBy(Guid userId)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);
            if (user is null)
                throw new EntityNotFoundException("O usuário informado não existe");

            if (user.UserType == UserType.User)
                return await _ticketsRepository.ListAllTicketsBy(userId);

            return await _ticketsRepository.ProjectManyBy(x => new ListTicketsDto
            {
                Code = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Desciption = x.Room.Description,
                }
            }, x => !x.IsDeleted);
        }

        public async Task<ListTicketsDto> ListById(Guid ticketId)
        {
            return await _ticketsRepository.ProjectOneBy(x => new ListTicketsDto
            {
                Code = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                CreatedAt = x.CreatedAt,
                Responsible = x.SupportUser.Name,
                RoomDto = new ListRoomDto
                {
                    Id = x.RoomId,
                    Name = x.Room.Name,
                    Desciption = x.Room.Description,
                },
                Images = x.TicketImages.Select(x => x.Image).ToList(),
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

            if (ticket.Status != TicketStatus.Finished)
                throw new InvalidDataException("Somente chamados em finalizados podem ser encerrados");

            ticket.CloseTicket();

            _ticketsRepository.UpdateOne(ticket);

            await SendTicketStatusUpdateEmailAsync(ticket, user);
        }

        // Somente o próprio usuário poderá excluir o chamado
        public async Task Delete(Guid id)
        {
            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (ticket is null)
                throw new EntityNotFoundException("O chamado informado não existe");

            if (ticket.Status != TicketStatus.Pending)
                throw new InvalidDataException("Um chamado em andamento ou concluído não pode ser excluído");

            ticket.SetDelete();

            _ticketsRepository.DeleteOne(ticket);
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
            var subject = "Status do Chamado foi Atualizado!";
            var message = @$"
                <p>Olá {user.Name},</p>
                <p>O status do seu chamado foi atualizado.</p>
                <p><b>Novo Status: </b>{ticket.Status.GetDescription()}</p>
                <p>Para acompanhar o seu chamado, aperte o botão abaixo:</p>
                <p><a href='#' class='btn'>Clique Aqui</a></p>
                <p>Qualquer dúvida estamos a disposição!.</p>";

            await _emailSenderService.SendEmailAsync(user.Email, subject, message);
        }
    }
}
