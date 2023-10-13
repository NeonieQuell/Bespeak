using Bespeak.Entity.Entities;

namespace Bespeak.Web.Models
{
    public class RoomDto
    {
        public string RoomId { get; set; } = string.Empty;

        public RoomType? RoomType { get; set; }

        public string Status { get; set; } = string.Empty;

        public int FloorNumber { get; set; }
    }
}
