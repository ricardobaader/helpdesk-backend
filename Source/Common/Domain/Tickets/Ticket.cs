using Common.Domain.Users;
using Common.Utils;
using System.Text.Json.Serialization;

namespace Common.Domain.Tickets
{
    public class Ticket : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Room { get; private set; }
        public TicketStatus Status { get; private set; }
        [JsonIgnore] public virtual User User { get; protected set; }
        public Guid UserId { get; set; }

        public Ticket(string title, string description, string room, Guid userId)
        {
            ValidateInfo(title, description, room);

            if (IsValid)
            {
                SetBaseProperties();
                Title = title;
                Description = description;
                Room = room;
                Status = TicketStatus.Pending;
                UserId = userId;
            }
        }

        private void ValidateInfo(string title, string description, string room) => Errors = EntityValidator.New()
            .Requiring(title, "O título deve ser informado")
            .Requiring(description, "A descrição deve ser informada")
            .Requiring(room, "A sala deve ser informada")
            .GetErrors();
    }
}
