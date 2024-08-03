using System.ComponentModel.DataAnnotations;

namespace Bespeak.Web.Models
{
    public class RoomDto
    {
        public int RoomId { get; set; }

        /// <summary>
        /// The RoomTypeId of RoomTypeDto Object
        /// </summary>
        public Guid RoomTypeId { get; set; }

        /// <summary>
        /// The RoomTypeDto Object of RoomTypeId Property
        /// </summary>
        public RoomTypeDto RoomType { get; set; } = null!;

        /// <summary>
        /// The RoomStatusId of RoomStatusDto Object
        /// </summary>
        public int RoomStatusId { get; set; }

        /// <summary>
        /// The RoomStatusDto Object of RoomStatusId Property
        /// </summary>
        public RoomStatusDto RoomStatus { get; set; } = null!;

        public int FloorNumber { get; set; }
    }

    public class RoomDtoForCreate
    {
        [Required]
        public Guid RoomTypeId { get; set; }

        [Required]
        public int FloorNumber { get; set; }
    }

    public class RoomDtoForUpdate
    {
        public int RoomId { get; set; }

        public Guid RoomTypeId { get; set; }

        public int RoomStatusId { get; set; }
    }
}
