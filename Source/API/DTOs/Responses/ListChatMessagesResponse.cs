using Common.Domain.Rooms;

namespace API.DTOs.Responses
{
    public class ListChatMessagesResponse
    {
        public string Message { get; init; }

        public DateTime SendedAt { get; init; }

        public static ListChatMessagesResponse ToLListChatMessagesResponse(ListChatMessagesDto chatMessagesDto) => new()
        {
            Message = chatMessagesDto.Message,
            SendedAt = chatMessagesDto.SendedAt
        };
    }
}
