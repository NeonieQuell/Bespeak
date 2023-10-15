using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomRepository
    {
        Task<Room?> GetRoomByIdAsync(string roomId);

        Task<IEnumerable<Room>> GetRoomsAsync();

        Task AddAsync(Room room);
    }
}
