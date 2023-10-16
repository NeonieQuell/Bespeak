using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class BookingsViewModel
    {
        public List<RoomDto> Rooms { get; set; }

        public BookingsViewModel()
        {
            Rooms = new List<RoomDto>();
        }
    }
}
