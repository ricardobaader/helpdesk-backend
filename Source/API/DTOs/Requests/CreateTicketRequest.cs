using Common.Domain.Tickets;

namespace API.DTOs.Requests
{
    public class CreateTicketRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        public CreateTicketDto ToCreateTicketDto()
        {
            return new()
            {
                Title = Title,
                Description = Description,
                RoomId = RoomId,
                UserId = UserId,
                Images = Images
            };
        }
    }
}
