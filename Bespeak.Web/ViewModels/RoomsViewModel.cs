using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class RoomsViewModel
    {
        public List<RoomTypeDto> RoomTypes { get; set; }

        public List<RoomDto> Rooms { get; set; }

        public RoomsViewModel()
        {
            RoomTypes = new List<RoomTypeDto>();
            Rooms = new List<RoomDto>();
        }
    }
}
