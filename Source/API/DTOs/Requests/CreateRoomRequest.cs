using Common.Domain.Rooms;

namespace API.DTOs.Requests
{
    public class CreateRoomRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateRoomDto ToCreateRoomRequest() => new()
        {
            Name = Name,
            Description = Description
        };
    }
}
