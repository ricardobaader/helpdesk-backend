using Common.Domain.Rooms;

namespace Common.Application.Services.Rooms
{
    public interface IRoomsService
    {
        IEnumerable<ListRoomDto> GetRooms();
        Task Create(CreateRoomDto request);
        Task Update(Guid id, UpdateRoomDto request);
    }
}
