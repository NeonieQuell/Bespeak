using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BespeakDbContext _dbContext;

        public RoomRepository(BespeakDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Room room)
        {
            var count = Convert.ToString(await _dbContext.Rooms.CountAsync() + 1);
            room.RoomId = $"RM{count}";

            room.Status = "Available";

            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(string roomId)
        {
            return await _dbContext.Rooms.FindAsync(roomId);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _dbContext.Rooms.ToListAsync();
        }
    }
}
