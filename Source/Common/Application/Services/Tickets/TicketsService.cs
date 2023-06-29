using Common.Domain;
using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    internal class TicketsService : ITicketsService
    {
        private readonly IBaseEntityRepository<Ticket> _ticketRepository;

        public TicketsService(IBaseEntityRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task Create(CreateTicketDto request)
        {
            var ticket = TicketMapper.MapCreateTicketDtoToTicket(request);
            await _ticketRepository.InsertOne(ticket);
        }
    }
}
