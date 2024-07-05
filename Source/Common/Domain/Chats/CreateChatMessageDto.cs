using Microsoft.AspNetCore.Http;

namespace Common.Domain.Chats
{
    public class CreateChatMessageDto
    {
        public string Message { get; set; }
        public IFormFile Image { get; set; }
    }
}
