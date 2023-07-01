namespace Common.Domain.Rooms
{
    public class Room : BaseEntity
    {
        public string Name { get; init; }

        public Room() => SetBaseProperties();
    }
}
