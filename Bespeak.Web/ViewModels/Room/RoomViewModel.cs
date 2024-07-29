using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels.Room
{
    public class RoomViewModel
    {
        public List<RoomTypeDto> RoomTypes { get; set; }

        public List<RoomDto> Rooms { get; set; }

        public RoomViewModel()
        {
            RoomTypes = new List<RoomTypeDto>();
            Rooms = new List<RoomDto>();
        }
    }
}
