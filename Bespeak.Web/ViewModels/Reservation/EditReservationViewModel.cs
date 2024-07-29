using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels.Reservation
{
    public class EditReservationViewModel
    {
        public ReservationDtoForUpdate? Reservation { get; set; }

        public List<RoomDto> Rooms { get; set; }

        public EditReservationViewModel()
        {
            Rooms = new List<RoomDto>();
        }
    }
}
