using Common.Domain.Tickets;

namespace API.DTOs.Requests
{
    public class CreateTicketRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Room { get;  set; }
        public Guid UserId { get; set; }


        public CreateTicketDto ToCreateTicketDto() => new()
        {
            Title = Title,
            Description = Description,
            Room = Room,
            UserId = UserId
        };
    }
}
