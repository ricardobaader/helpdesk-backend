using API.DTOs.Requests;
using Common.Application.Services.Chats;
using Common.Domain.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ChatsController : BaseController
    {
        private readonly IChatsService _chatsService;

        public ChatsController(IChatsService chatsService)
        {
            _chatsService = chatsService;
        }

        [Authorize]
        [HttpPost("ticket/{ticketId}/user/{userId}")]
        public async Task<IActionResult> SendMessage([FromRoute] Guid ticketId, Guid userId, [FromBody] CreateChatMessageRequest request)
        {
            await _chatsService.SendMessage(ticketId, userId, request.Message);
            return Ok();
        }

        [Authorize]
        [HttpGet("ticket/{ticketId}")]
        public ActionResult GetMessages([FromRoute] Guid ticketId)
        {
            var messages = _chatsService.ListAllMessages(ticketId);
            if (messages is null)
                return NotFound(string.Empty);

            return Ok(messages);
        }

    }
}
