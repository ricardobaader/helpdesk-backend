using Common.Domain.Chats;
using Common.Domain.Rooms;
using Common.Domain.TicketImages;
using Common.Domain.Users;
using Common.Utils;
using System.Text.Json.Serialization;

namespace Common.Domain.Tickets
{
    public class Ticket : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TicketStatus Status { get; private set; }

        [JsonIgnore]
        public virtual User User { get; protected set; }
        public Guid UserId { get; private set; }

        [JsonIgnore]
        public virtual Room Room { get; protected set; }
        public Guid RoomId { get; private set; }

        [JsonIgnore]
        public virtual User SupportUser { get; protected set; }
        public Guid? SupportUserId { get; private set; }

        private readonly IList<TicketImage> _ticketImages = new List<TicketImage>();
        [JsonIgnore] public virtual ICollection<TicketImage> TicketImages => _ticketImages;

        private readonly IList<Chat> _chats = new List<Chat>();
        [JsonIgnore] public virtual ICollection<Chat> Chats => _chats;

        protected Ticket() { }

        public Ticket(string title, string description, Guid roomId, Guid userId)
        {
            ValidateInfo(title, description, roomId, userId);

            if (IsValid)
            {
                SetBaseProperties();
                Title = title;
                Description = description;
                RoomId = roomId;
                Status = TicketStatus.Pending;
                UserId = userId;
            }
        }

        public void StartTicket(Guid supportUserId)
        {
            SetUpdate();
            Status = TicketStatus.InProgress;
            SupportUserId = supportUserId;
        }

        public void FinishTicket()
        {
            SetUpdate();
            Status = TicketStatus.Solved;
        }

        public void CloseTicket()
        {
            SetDelete();
            Status = TicketStatus.Closed;
        }

        private void ValidateInfo(string title, string description, Guid roomId, Guid userId) => Errors = EntityValidator.New()
            .Requiring(title, "É necessário informar um título")
            .Requiring(description, "É necessário informar uma descrição")
            .Requiring(roomId, "É necessário informar um ID da sala")
            .Requiring(userId, "É necessário informar um ID do usuário")
            .GetErrors();
    }
}
