using Bespeak.Entity.Entities;

namespace Bespeak.Web.Models
{
    public class BookingDto
    {
        public string BookingId { get; set; } = string.Empty;

        public Room? Room { get; set; }

        public string BookedBy { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Duration
        {
            get
            {
                var timeDifference = (int)EndDate.Subtract(StartDate).TotalDays;
                string suffix = timeDifference > 1 ? "days" : "day";
                return $"{timeDifference} {suffix}";
            }
        }
    }
}
