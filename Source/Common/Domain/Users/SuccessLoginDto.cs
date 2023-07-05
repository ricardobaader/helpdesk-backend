namespace Common.Domain.Users
{
    public class SuccessLoginDto
    {
        public string Name { get; init; }
        public string UserType { get; init; }
        public Guid UserId { get; init; }
        public bool IsSuccess { get; init; }
    }
}
