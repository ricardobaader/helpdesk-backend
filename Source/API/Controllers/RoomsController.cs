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
            var roomId = await _roomsService.Create(request.ToCreateRoomRequest());
            return Created(string.Empty, roomId);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoom([FromRoute] Guid id, [FromBody] UpdateRoomRequest request)
        {
            await _roomsService.Update(id, request.ToUpdateRoomDto());
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] Guid id)
        {
            await _roomsService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoomById([FromRoute] Guid id)
        {
            var room = await _roomsService.ListById(id);

            if (room is null)
                return NotFound(string.Empty);

            return Ok(room);
        }

        [HttpGet("{id}/qrcode")]
        public async Task<ActionResult> GetRoomQRCode([FromRoute] Guid id)
        {
            var room = await _roomsService.ListSpecificRoomQRCode(id);

            if (string.IsNullOrEmpty(room))
                return NotFound(string.Empty);

            return Ok(room);
        }
    }
}
