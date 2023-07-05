using Common.Application.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;
        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        [HttpGet]
        public ActionResult<IList<string>> GetRooms() =>
            Ok(_roomsService.GetRooms());
    }
}
