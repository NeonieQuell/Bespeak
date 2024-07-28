using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class ReservationViewModel
    {
        public List<RoomDto> Rooms { get; set; }

        public List<ReservationDto> Reservations { get; set; }

        public ReservationViewModel()
        {
            Rooms = new List<RoomDto>();
            Reservations = new List<ReservationDto>();
        }
    }
}
