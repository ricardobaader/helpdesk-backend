﻿using Common.Domain.Rooms;
using Common.Domain.Tickets;

namespace API.DTOs.Responses
{
    public class ListTicketsResponse
    {
        public Guid Id { get; init; }
        public int Number { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public ListRoomDto Room { get; init; }
        public string CreatedAt { get; init; }

        public static ListTicketsResponse ToListTicketsResponse(ListTicketsDto listTicketsDto)
        {
            if (listTicketsDto != null)
                return new()
                {
                    Id = listTicketsDto.Id,
                    Number = listTicketsDto.Number,
                    Title = listTicketsDto.Title,
                    Description = listTicketsDto.Description,
                    Status = listTicketsDto.Status,
                    CreatedAt = listTicketsDto.CreatedAt.ToString("dd/MM/yyyy"),
                    Room = listTicketsDto.RoomDto,
                };

            return default;
        }
    }
}
