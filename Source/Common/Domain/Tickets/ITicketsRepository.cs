namespace Common.Domain.Tickets
{
    public interface ITicketsRepository : IBaseEntityRepository<Ticket>
    {
        Task<IEnumerable<ListTicketsDto>> ListTicketsBy(Guid userId);
    }
}
