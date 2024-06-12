using Common.Domain.Rooms;

namespace Common.Application.Services.Rooms
{
    public interface IRoomsService
    {
        IEnumerable<ListRoomDto> GetRooms();
        Task<Guid> Create(CreateRoomDto request);
        Task Update(Guid id, UpdateRoomDto request);
        Task Delete(Guid id);
        Task<ListRoomDto> ListById(Guid roomId);
        Task<string> ListSpecificRoomQRCode(Guid roomId);
    }
}
