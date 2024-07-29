namespace Bespeak.Entity.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        /// <summary>
        /// The RoomTypeId of RoomType Object
        /// </summary>
        public Guid RoomTypeId { get; set; }

        /// <summary>
        /// The RoomType Object of RoomTypeId Property
        /// </summary>
        public RoomType? RoomType { get; set; }

        /// <summary>
        /// The RoomStatusId of RoomStatus Object
        /// </summary>
        public int RoomStatusId { get; set; }

        /// <summary>
        /// The RoomStatus Object of RoomStatusId Property
        /// </summary>
        public RoomStatus? RoomStatus { get; set; }

        public int FloorNumber { get; set; }

        public List<Reservation>? Reservations { get; set; }
    }
}
