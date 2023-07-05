using Common.Domain;
using Common.Domain.Rooms;

namespace Common.Application.Services.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly IBaseEntityRepository<Room> _roomsRepository;

        public RoomsService(IBaseEntityRepository<Room> roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public IEnumerable<string> GetRooms() =>
             _roomsRepository.ProjectManyBy(x => x.Name, x => !x.IsDeleted).Result.OrderBy(x => x);
    }
}
