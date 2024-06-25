namespace Common.Domain.Users
{
    public class ListUsersDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string UserType { get; init; }
    }
}
