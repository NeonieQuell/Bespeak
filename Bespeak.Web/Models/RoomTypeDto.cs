using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public class RoomTypeDtoForCreate
    {
        [Required]
        [MaxLength(32)]
        [DisplayName("Type")]
        public string TypeName { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Description { get; set; }
    }
}
