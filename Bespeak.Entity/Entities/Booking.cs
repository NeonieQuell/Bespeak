namespace Bespeak.Entity.Entities
{
    public class Booking
    {
        public string BookingId { get; set; } = string.Empty;

        public string RoomId { get; set; } = string.Empty;

        public Room? Room { get; set; }

        public string BookedBy { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
