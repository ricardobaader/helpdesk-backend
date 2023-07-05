namespace Common.Domain.Tickets
{
    public class ListTicketsDto
    {
        public Guid Code { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public string Room { get; init; }
    }
}
