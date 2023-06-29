namespace Common.Domain.Tickets
{
    public class CreateTicketDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string Room { get; init; }
        public Guid UserId { get; init; }
    }
}
