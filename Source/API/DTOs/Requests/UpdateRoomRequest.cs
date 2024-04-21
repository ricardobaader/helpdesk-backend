using Common.Domain.Rooms;

namespace API.DTOs.Requests
{
    public class UpdateRoomRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public UpdateRoomDto ToUpdateRoomDto() => new()
        {
            Name = Name,
            Description = Description
        };
    }
}
