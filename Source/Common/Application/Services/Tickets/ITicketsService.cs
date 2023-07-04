using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public interface ITicketsService
    {
        Task Create(CreateTicketDto request);
        Task<IEnumerable<ListTicketsDto>> ListTicketsBy(Guid userId);
        Task StartTicket(Guid id, Guid userId);
        Task FinishTicket(Guid id, Guid userId);
    }
}
