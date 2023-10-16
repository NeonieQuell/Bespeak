using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalRoomsCount { get; set; }

        public int AvailableRoomsCount { get; set; }

        public int OccupiedRoomsCount { get; set; }

        public List<BookingDto> Bookings { get; set; }

        public DashboardViewModel()
        {
            Bookings = new List<BookingDto>();
        }
    }
}
