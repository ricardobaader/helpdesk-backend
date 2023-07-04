using Common.Domain.Tickets;

namespace API.DTOs.Responses
{
    public class ListTicketsResponse
    {
        public Guid Code { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }

        public static ListTicketsResponse ToListTicketsResponse(ListTicketsDto listTicketsDto) => new()
        {
            Title = listTicketsDto.Title,
            Description = listTicketsDto.Description,
            Status = listTicketsDto.Status,
            Code = listTicketsDto.Code,
        };
    }
}
