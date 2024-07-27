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

        public async Task<Room?> GetRoomByIdAsync(string roomId, bool includeType, bool trackEntity)
        {
            var rooms = _dbContext.Rooms as IQueryable<Room>;

            if (includeType)
                rooms = rooms.Include(r => r.RoomType);

            if (!trackEntity)
                rooms = rooms.AsNoTracking();

            return await rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _dbContext.Rooms.Include(r => r.RoomType).AsNoTracking().ToListAsync();
        }

        public async Task<(int total, int available, int occupied)> GetRoomsCountAsync()
        {
            int totalCount = await _dbContext.Rooms.CountAsync();
            int availableCount = await _dbContext.Rooms.CountAsync(r => r.Status == "Available");
            int occupiedCount = await _dbContext.Rooms.CountAsync(r => r.Status == "Occupied");

            return (totalCount, availableCount, occupiedCount);
        }

        public async Task<int> GetRoomsCountByRoomTypeAsync(string typeName)
        {
            return await _dbContext.Rooms.CountAsync(r => r.RoomType!.TypeName == typeName);
        }

        public async Task UpdateStatusAsync(string roomId, string status)
        {
            await _dbContext.Rooms
                .Where(r => r.RoomId == roomId)
                .ExecuteUpdateAsync(r => r.SetProperty(r => r.Status, status));
        }
    }
}
