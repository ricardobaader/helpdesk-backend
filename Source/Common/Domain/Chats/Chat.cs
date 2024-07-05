using Common.Domain.Tickets;
using Common.Domain.Users;
using System.Text.Json.Serialization;

namespace Common.Domain.Chats
{
    public class Chat : BaseEntity
    {
        public string Message { get; private set; }
        public byte[] Image { get; private set; }

        [JsonIgnore]
        public virtual User User { get; protected set; }
        public Guid UserId { get; private set; }

        [JsonIgnore]
        public virtual Ticket Ticket { get; protected set; }
        public Guid TicketId { get; private set; }

        public Chat(string message, byte[] image, Guid userId, Guid ticketId)
        {
            SetBaseProperties();

            Message = message;
            UserId = userId;
            TicketId = ticketId;
            Image = image;
        }
    }
}
