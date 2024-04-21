using Common.Domain;
using Common.Domain.Rooms;
using Common.Exceptions;
using InvalidDataException = Common.Exceptions.InvalidDataException;

namespace Common.Application.Services.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly IBaseEntityRepository<Room> _roomsRepository;

        public RoomsService(IBaseEntityRepository<Room> roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public IEnumerable<ListRoomDto> GetRooms()
        {
            return _roomsRepository
               .ProjectManyBy(x => new ListRoomDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Desciption = x.Description
               }, x => !x.IsDeleted)
               .Result.OrderBy(x => x.Name);
        }

        public async Task Create(CreateRoomDto request)
        {
            var roomExists = await _roomsRepository.ExistsBy(x => x.Name == request.Name && !x.IsDeleted);
            if (roomExists)
                throw new ExistingEntityException("Já existe uma sala com o nome informado");

            var room = new Room(request.Name, request.Description);

            if (room.IsValid == false)
                throw new InvalidDataException($"Não foi possível criar a sala porque existem incoerências nos dados Errors: {string.Join("; ", room.Errors)}");

            await _roomsRepository.InsertOne(room);
        }

        public async Task Update(Guid id, UpdateRoomDto request)
        {
            var roomDb = await _roomsRepository.SelectOneBy(x => x.Id == id && !x.IsDeleted);
            if (roomDb is null)
                throw new EntityNotFoundException("A sala informada não existe");

            var roomExistsWithSameName = await _roomsRepository.ExistsBy(x => x.Id != roomDb.Id && x.Name == request.Name && !x.IsDeleted);
            if (roomExistsWithSameName)
                throw new ExistingEntityException("Já existe uma sala com o nome informado");

            roomDb.Update(request.Name ?? roomDb.Name, request.Description ?? roomDb.Description);

            if (roomDb.IsValid == false)
                throw new InvalidDataException($"Não foi possível atualizar a sala porque existem incoerências nos dados Errors: {string.Join("; ", roomDb.Errors)}");

            _roomsRepository.UpdateOne(roomDb);
        }
    }
}
