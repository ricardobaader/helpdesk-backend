using Common.Domain.Rooms;
using Common.Domain.Tickets;

namespace API.DTOs.Responses
{
    public class ListTicketsResponse
    {
        public Guid Code { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public string Responsible { get; init; }
        public ListRoomDto Room { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<string> ImagesBase64 { get; init; }

        public static ListTicketsResponse ToListTicketsResponse(ListTicketsDto listTicketsDto)
        {
            return new()
            {
                Code = listTicketsDto.Code,
                Title = listTicketsDto.Title,
                Description = listTicketsDto.Description,
                Status = listTicketsDto.Status,
                Responsible = listTicketsDto.Responsible,
                CreatedAt = listTicketsDto.CreatedAt,
                Room = listTicketsDto.RoomDto,
                ImagesBase64 = listTicketsDto.Images?.Select(x => Convert.ToBase64String(x)).ToList(),
            };
        }
    }
}
