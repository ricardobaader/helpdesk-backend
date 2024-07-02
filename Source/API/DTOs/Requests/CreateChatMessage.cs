using Common.Domain.Chats;

namespace API.DTOs.Requests
{
    public class CreateChatMessageRequest
    {
        public string Message { get; set; }
        public IFormFile Image { get; set; }

        public CreateChatMessageDto ToCreateChatMessageDto()
        {
            return new()
            {
                Message = Message,
                Image = Image
            };
        }
    }
}
