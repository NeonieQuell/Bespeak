﻿namespace Bespeak.Entity.Entities
{
    public class RoomStatus
    {
        public int RoomStatusId { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<Room>? Rooms { get; set; }
    }
}
