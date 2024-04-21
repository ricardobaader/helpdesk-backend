using Microsoft.AspNetCore.Http;

namespace Common.Domain.Tickets
{
    public class CreateTicketDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public Guid RoomId { get; init; }
        public Guid UserId { get; init; }
        public List<IFormFile> Images { get; init; }
    }
}
