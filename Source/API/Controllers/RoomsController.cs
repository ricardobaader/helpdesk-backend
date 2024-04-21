using API.DTOs.Requests;
using Common.Application.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        [HttpGet]
        public ActionResult<IList<string>> GetRooms() =>
            Ok(_roomsService.GetRooms());

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
        {
            await _roomsService.Create(request.ToCreateRoomRequest());
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoom([FromRoute] Guid id, [FromBody] UpdateRoomRequest request)
        {
            await _roomsService.Update(id, request.ToUpdateRoomDto());
            return Ok();
        }
    }
}
