namespace Bespeak.Entity.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        /// <summary>
        /// The RoomId of Room Object
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// The Room Object of RoomId Property
        /// </summary>
        public Room? Room { get; set; }

        /// <summary>
        /// The person's name who reserved
        /// </summary>
        public string Reserver { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
