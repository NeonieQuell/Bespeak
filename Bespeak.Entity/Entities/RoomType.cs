﻿namespace Bespeak.Entity.Entities
{
    public class RoomType
    {
        public Guid RoomTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public IEnumerable<Room>? Rooms { get; set; }
    }
}
