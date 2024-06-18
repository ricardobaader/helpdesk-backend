using Common.Domain.Tickets;
using System.Text.Json.Serialization;

namespace Common.Domain.TicketImages
{
    public class TicketImage : BaseEntity
    {
        public byte[] Image { get; private set; }

        [JsonIgnore] 
        public virtual Ticket Ticket { get; protected set; }
        public Guid TicketId { get; set; }

        public TicketImage(Guid ticketId, byte[] image) 
        { 
            SetBaseProperties();
            TicketId = ticketId;
            Image = image;
        }
    }
}
