﻿using Common.Domain.Rooms;

namespace Common.Domain.Tickets
{
    public class ListTicketsDto
    {
        public Guid Code { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Status { get; init; }
        public string Responsible { get; init; }
        public ListRoomDto RoomDto { get; init; }
        public List<byte[]> Images { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
