using Common.Domain.Tickets;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace API.DTOs.Requests
{
    public class TicketsFiltersRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TicketStatus? Status { get; set; }

        public TicketsFiltersDto ToTicketsFiltersDto() => new()
        {
            TicketStatus = Status,
        };
    }
}