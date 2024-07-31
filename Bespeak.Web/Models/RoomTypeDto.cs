using System.ComponentModel.DataAnnotations;

namespace Bespeak.Web.Models
{
    public class RoomTypeDto
    {
        public Guid RoomTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int TotalRoomsOfType { get; set; }

        public int TotalReservedOfType { get; set; }
    }

    public class RoomTypeDtoForCreate
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Description { get; set; }
    }

    public class RoomTypeDtoForUpdate
    {
        [Required]
        public Guid RoomTypeId { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Description { get; set; }
    }
}
