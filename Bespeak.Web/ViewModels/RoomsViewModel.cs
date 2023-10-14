using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels
{
    public class RoomsViewModel
    {
        public List<RoomTypeDto> RoomTypes { get; set; }

        public RoomsViewModel()
        {
            RoomTypes = new List<RoomTypeDto>();
        }
    }
}
