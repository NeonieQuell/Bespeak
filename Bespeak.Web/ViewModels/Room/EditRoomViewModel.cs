using Bespeak.Web.Models;

namespace Bespeak.Web.ViewModels.Room;

public class EditRoomViewModel
{
    public RoomDto Room { get; set; } = null!;

    public List<RoomTypeDto> RoomTypes { get; set; }

    public EditRoomViewModel()
    {
        RoomTypes = new();
    }
}
