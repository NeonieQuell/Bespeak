namespace Bespeak.Entity.Entities
{
    public class Room
    {
        public string RoomId { get; set; } = string.Empty;

        public string RoomTypeId = string.Empty;

        public RoomType? RoomType { get; set; }

        public string Status { get; set; } = string.Empty;

        public int FloorNumber { get; set; }
    }
}
