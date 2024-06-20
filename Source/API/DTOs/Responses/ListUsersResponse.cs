using Common.Domain.Users;

namespace API.DTOs.Responses
{
    public class ListUsersResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }

        public static ListUsersResponse ToListUsersResponse(ListUsersDto usersDto) => new()
        {
            Id = usersDto.Id,
            Name = usersDto.Name,
            Email = usersDto.Email,
            Role = usersDto.UserType,
        };
    }
}
