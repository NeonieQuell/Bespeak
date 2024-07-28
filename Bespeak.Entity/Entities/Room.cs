using Bespeak.Constants.Enums;

namespace Bespeak.Entity.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        
        /// <summary>
        /// The RoomTypeId of RoomType Object
        /// </summary>
        public Guid RoomTypeId { get; set; }

        /// <summary>
        /// The RoomType Object of RoomTypeId Property
        /// </summary>
        public RoomType? RoomType { get; set; }

        public RoomStatus Status { get; set; }

        public int FloorNumber { get; set; }
    }
}
