namespace Bespeak.Web.Models
{
    public class RoomDto
    {
        public string RoomId { get; set; } = string.Empty;

        public string RoomTypeId { get; set; } = string.Empty;

        public RoomTypeDto RoomType { get; set; } = null!;

        public string Status { get; set; } = string.Empty;

        public int FloorNumber { get; set; }
    }

    public class RoomDtoForCreate
    {
        public string RoomTypeId { get; set; } = string.Empty;

        public int FloorNumber { get; set; }
    }

    public class RoomDtoForUpdate
    {
        public string RoomId { get; set; } = string.Empty;

        public string RoomTypeId { get; set; } = string.Empty;

        public RoomTypeDto RoomType { get; set; } = null!;

        public string Status { get; set; } = string.Empty;
    }
}
