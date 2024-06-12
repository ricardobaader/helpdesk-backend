using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public interface ITicketsService
    {
        Task<Guid> Create(CreateTicketDto request);
        Task<IEnumerable<ListTicketsDto>> ListAllBy(Guid userId);
        Task<ListTicketsDto> ListById(Guid ticketId);
        Task Start(Guid id, Guid supportUserId);
        Task Finish(Guid id, Guid supportUserId);
        Task Close(Guid id, Guid userId);
        Task Delete(Guid id);
    }
}
