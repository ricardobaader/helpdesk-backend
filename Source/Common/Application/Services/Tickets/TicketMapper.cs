using Common.Domain.Tickets;

namespace Common.Application.Services.Tickets
{
    public static class TicketMapper
    {
        public static Ticket MapCreateTicketDtoToTicket(CreateTicketDto dto) =>
            new(dto.Title, dto.Description, dto.RoomId, dto.UserId);
    }
}
