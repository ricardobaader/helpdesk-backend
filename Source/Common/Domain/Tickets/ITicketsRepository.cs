namespace Common.Domain.Tickets
{
    public interface ITicketsRepository : IBaseEntityRepository<Ticket>
    {
        Task<IEnumerable<ListTicketsDto>> ListAllTicketsBy(Guid userId, TicketsFiltersDto filters);
        Task<IEnumerable<Ticket>> ListAllSolvedTickets();
    }
}
