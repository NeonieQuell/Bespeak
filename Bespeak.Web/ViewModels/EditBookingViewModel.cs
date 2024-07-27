using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class EditBookingViewModel
    {
        public BookingDtoForUpdate Booking { get; set; } = null!;

        public List<RoomDto> Rooms { get; set; }

        public EditBookingViewModel()
        {
            Rooms = new List<RoomDto>();
        }
    }
}
