using Common.Domain.Tickets;
using System.Text.Json.Serialization;

namespace Common.Domain.TicketImages
{
    public class TicketImage : BaseEntity
    {
        [JsonIgnore] public virtual Ticket Ticket { get; protected set; }
        public Guid TicketId { get; set; }
        public byte[] Image { get; private set; }

        public TicketImage(Guid ticketId, byte[] image) 
        { 
            SetBaseProperties();
            TicketId = ticketId;
            Image = image;
        }
    }
}
