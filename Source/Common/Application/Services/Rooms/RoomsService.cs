using Common.Domain;
using Common.Domain.Rooms;
using Common.Domain.Tickets;
using Common.Exceptions;
using Common.Utils;
using InvalidDataException = Common.Exceptions.InvalidDataException;

namespace Common.Application.Services.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly IBaseEntityRepository<Room> _roomsRepository;
        private readonly IBaseEntityRepository<Ticket> _ticketsRepository;

        public RoomsService(IBaseEntityRepository<Room> roomsRepository,
            IBaseEntityRepository<Ticket> ticketsRepository)
        {
            _roomsRepository = roomsRepository;
            _ticketsRepository = ticketsRepository;
        }

        public IEnumerable<ListRoomDto> GetRooms()
        {
            return _roomsRepository
               .ProjectManyBy(x => new ListRoomDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
               }, x => !x.IsDeleted)
               .Result.OrderBy(x => x.Name);
        }

        public async Task<Guid> Create(CreateRoomDto request)
        {
            var roomExists = await _roomsRepository.ExistsBy(x => x.Name == request.Name && !x.IsDeleted);
            if (roomExists)
                throw new ExistingEntityException("Já existe uma sala com o nome informado");

            var room = new Room(request.Name, request.Description);

            if (room.IsValid == false)
                throw new InvalidDataException($"Não foi possível criar a sala porque existem incoerências nos dados Errors: {string.Join("; ", room.Errors)}");

            var qrCodeByteArray = QRCodeGeneratorHelper.GenerateQRCode(room.Id);

            room.SetQrCode(qrCodeByteArray);

            await _roomsRepository.InsertOne(room);

            return room.Id;
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

            var qrCodeByteArray = QRCodeGeneratorHelper.GenerateQRCode(roomDb.Id);

            roomDb.SetQrCode(qrCodeByteArray);

            _roomsRepository.UpdateOne(roomDb);
        }

        public async Task Delete(Guid id)
        {
            var roomDb = await _roomsRepository.SelectOneBy(x => x.Id == id);
            if (roomDb is null)
                throw new EntityNotFoundException("A sala informada não existe");

            var existTicketWithRoom = await _ticketsRepository.ExistsBy(x => x.RoomId == roomDb.Id && !x.IsDeleted);
            if (existTicketWithRoom)
                throw new ActiveObjectException("Não foi possível excluir esta sala porque ela está vinculada a um chamado ativo.");

            roomDb.SetDelete();
            _roomsRepository.UpdateOne(roomDb);
        }

        public async Task<ListRoomDto> ListById(Guid roomId)
        {
            return await _roomsRepository.ProjectOneBy(x => new ListRoomDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }, x => x.Id == roomId && !x.IsDeleted);
        }

        public async Task<string> ListSpecificRoomQRCode(Guid roomId)
        {
            var qrCodeByteArray = await _roomsRepository.ProjectOneBy(x => x.QrCode, x => x.Id == roomId && !x.IsDeleted);
            if (qrCodeByteArray != null)
                return Convert.ToBase64String(qrCodeByteArray);

            return string.Empty;
        }
    }
}
