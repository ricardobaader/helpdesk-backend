using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public interface ITicketsService
    {
        Task Create(CreateTicketDto request);
        Task<IEnumerable<ListTicketsDto>> ListBy(Guid userId);
        Task Start(Guid id, Guid userId);
        Task Finish(Guid id, Guid userId);
        Task Delete(Guid id);
    }
}
