using Common.Domain.Tickets;
using Common.Utils;
using System.Text.Json.Serialization;

namespace Common.Domain.Rooms
{
    public class Room : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly IList<Ticket> _tickets = new List<Ticket>();
        [JsonIgnore] public virtual ICollection<Ticket> Tickets => _tickets;

        protected Room() { }

        public Room(string name, string description)
        {
            ValidateInformation(name, description);

            if (IsValid)
            {
                SetBaseProperties();
                Name = name;
                Description = description;
            }
        }

        public void Update(string name, string description)
        {
            ValidateInformation(name, description);

            if (IsValid)
            {
                Name = name;
                Description = description;
            }
        }

        private void ValidateInformation(string name, string description)
        {
            Errors = EntityValidator.New()
                .Requiring(name, "É necessário informar um nome")
                .Requiring(description, "É necessário informar uma descrição")
                .GetErrors();
        }

    }
}
