namespace Common.Domain.Tickets
{
    public class Ticket : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Room { get; private set; }

        public Ticket(string title, string description, string room)
        {
            SetBaseProperty();
            Title = title;
            Description = description;
            Room = room;
        }
    }
}
