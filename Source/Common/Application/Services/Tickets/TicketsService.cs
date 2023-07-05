using Common.Domain;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Utils.Extensions;

namespace Common.Application.Services.Tickets
{
    internal class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IBaseEntityRepository<User> _usersRepository;

        public TicketsService(ITicketsRepository ticketRepository, IBaseEntityRepository<User> usersRepository)
        {
            _ticketsRepository = ticketRepository;
            _usersRepository = usersRepository;
        }

        public async Task Create(CreateTicketDto request)
        {
            var ticket = TicketMapper.MapCreateTicketDtoToTicket(request);
            await _ticketsRepository.InsertOne(ticket);
        }

        public async Task<IEnumerable<ListTicketsDto>> ListBy(Guid userId)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);

            if (user is null)
                throw new Exceptions.EntityNotFoundException("O usuário informado não existe");

            if (user.UserType == UserType.User)
                return await _ticketsRepository.ListTicketsBy(userId);

            return await _ticketsRepository.ProjectManyBy(x => new ListTicketsDto
            {
                Code = x.Id,
                Description = x.Description,
                Status = x.Status.GetDescription(),
                Title = x.Title,
                Room = x.Room,
            }, x => !x.IsDeleted);
        }

        public async Task Start(Guid id, Guid userId)
        {
            var ticket = await ValidateIfTicketCanChangeStatus(id, userId);

            ticket.StartTicket();

            _ticketsRepository.UpdateOne(ticket);
        }

        public async Task Finish(Guid id, Guid userId)
        {
            var ticket = await ValidateIfTicketCanChangeStatus(id, userId);

            if (ticket.Status != TicketStatus.InProgress)
                throw new Exceptions.InvalidDataException("Somente chamados em progresso podem ser finalizados");

            ticket.FinishTicket();

            _ticketsRepository.UpdateOne(ticket);
        }

        private async Task<Ticket> ValidateIfTicketCanChangeStatus(Guid id, Guid userId)
        {
            var user = await _usersRepository.SelectOneBy(x => x.Id == userId && !x.IsDeleted);

            if (user is null)
                throw new Exceptions.EntityNotFoundException("O usuário informado não existe");

            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);

            if (ticket is null)
                throw new Exceptions.EntityNotFoundException("O chamado informado não existe");

            if (user.UserType != UserType.Employee)
                throw new Exceptions.InvalidDataException("Somente um funcionário da equipe de suporte pode alterar um chamado");

            return ticket;
        }

        public async Task Delete(Guid id)
        {
            var ticket = await _ticketsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);

            if (ticket is null)
                throw new Exceptions.EntityNotFoundException("O ticket informado não existe");

            if (ticket.Status != TicketStatus.Pending)
                throw new Exceptions.InvalidDataException("Um ticket em andamento ou concluído não pode ser excluído");

            ticket.SetDelete();

            _ticketsRepository.DeleteOne(ticket);
        }
    }
}
