using API.DTOs.Requests;
using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public interface ITicketsService
    {
        Task<Guid> Create(CreateTicketDto request);
        Task<IEnumerable<ListTicketsDto>> ListAllBy(Guid userId, TicketsFiltersRequest request);
        Task<IEnumerable<ListTicketsDto>> ListAllTicketsTakedBy(Guid supportUserId);
        Task<ListTicketsDto> ListById(Guid ticketId);
        Task Start(Guid id, Guid supportUserId);
        Task Finish(Guid id, Guid supportUserId);
        Task Close(Guid id, Guid userId);
        Task Cancel(Guid id, Guid userId);
    }
}
