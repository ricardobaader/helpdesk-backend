using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public interface ITicketsService
    {
        Task Create(CreateTicketDto request);
    }
}
