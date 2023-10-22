namespace Bespeak.Web.Models
{
    public class BookingDto
    {
        public string BookingId { get; set; } = string.Empty;

        public RoomDto Room { get; set; } = null!;

        public string BookedBy { get; set; } = string.Empty;

        public DateTime DateBooked { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateOnly DateBookedFormatted
        {
            get
            {
                return DateOnly.FromDateTime(DateBooked);
            }
        }

        public DateOnly StartDateFormatted
        {
            get
            {
                return DateOnly.FromDateTime(StartDate);
            }
        }

        public DateOnly EndDateFormatted
        {
            get
            {
                return DateOnly.FromDateTime(EndDate);
            }
        }

        public string Duration
        {
            get
            {
                if (StartDate.Equals(EndDate))
                {
                    return "1 day";
                }
                else
                {
                    var timeDifference = (int)EndDate.Subtract(StartDate).TotalDays + 1;
                    string suffix = timeDifference > 1 ? "days" : "day";
                    return $"{timeDifference} {suffix}";
                }
            }
        }
    }

    public class BookingDtoForCreate
    {
        public string RoomId { get; set; } = string.Empty;

        public string BookedBy { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public class BookingDtoForUpdate
    {
        public string BookingId { get; set; } = string.Empty;

        public string RoomId { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
