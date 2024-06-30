using Common.Domain.Users;

namespace Common.Domain.Rooms
{
    public class ListChatMessagesDto
    {
        public string Message { get; init; }
        public DateTime SendedAt { get; init; }
        public ListUsersDto User {  get; init; }
    }
}
