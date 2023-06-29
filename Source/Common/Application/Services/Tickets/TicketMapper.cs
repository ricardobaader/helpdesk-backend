using Common.Domain.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Services.Tickets
{
    public static class TicketMapper
    {
        public static Ticket MapCreateTicketDtoToTicket(CreateTicketDto dto) =>
            new(dto.Title, dto.Description, dto.Room, dto.UserId);
    }
}
