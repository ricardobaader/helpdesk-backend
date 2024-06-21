using Common.Domain.Rooms;
using Common.Domain.Tickets;

namespace API.DTOs.Responses
{
    public class ListTicketDetailsResponse
    {
        public Guid Id { get; init; }
        public int Number { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public string Responsible { get; init; }
        public string Attendant { get; init; }
        public ListRoomDto Room { get; init; }
        public string CreatedAt { get; init; }
        public List<string> ImagesBase64 { get; init; }

        public static ListTicketDetailsResponse ToListTicketDetailsResponse(ListTicketsDto listTicketsDto)
        {
            if (listTicketsDto != null)
                return new()
                {
                    Id = listTicketsDto.Id,
                    Number = listTicketsDto.Number,
                    Title = listTicketsDto.Title,
                    Description = listTicketsDto.Description,
                    Status = listTicketsDto.Status,
                    Responsible = listTicketsDto.Responsible,
                    Attendant = listTicketsDto.Attendant,
                    CreatedAt = listTicketsDto.CreatedAt.ToString("dd/MM/yyyy"),
                    Room = listTicketsDto.RoomDto,
                    ImagesBase64 = listTicketsDto.Images?.Select(x => Convert.ToBase64String(x)).ToList(),
                };

            return default;
        }
    }
}
