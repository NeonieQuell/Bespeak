namespace Bespeak.Web.Models
{
    public class RoomTypeDto
    {
        public string RoomTypeId { get; set; } = string.Empty;

        public string TypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int TotalRoomsOfType { get; set; }

        public int TotalBookedOfType { get; set; }
    }
}
