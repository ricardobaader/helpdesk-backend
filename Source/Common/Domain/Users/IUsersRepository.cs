namespace Common.Domain.Users
{
    public interface IUsersRepository : IBaseEntityRepository<User>
    {
        Task<IEnumerable<ListUsersDto>> ListUsers();
    }
}
