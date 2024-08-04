using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = Bespeak.Constants.Enums;

namespace Bespeak.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BespeakDbContext dbContext;

        public RoomRepository(BespeakDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Room room)
        {
            room.RoomStatusId = (int)Enums.RoomStatus.Available;

            await this.dbContext.Room.AddAsync(room);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<(int total, int available, int occupied)> GetAllCountsAsync()
        {
            int totalCount = await this.dbContext.Room.CountAsync();
            int availableCount = await this.dbContext.Room.CountAsync(r => r.RoomStatusId == (int)Enums.RoomStatus.Available);
            int occupiedCount = await this.dbContext.Room.CountAsync(r => r.RoomStatusId == (int)Enums.RoomStatus.Occupied);

            return (totalCount, availableCount, occupiedCount);
        }

        public async Task<Room?> GetByIdAsync(int roomId, bool includeType, bool trackEntity = true)
        {
            var query = this.dbContext.Room as IQueryable<Room>;

            // Always include the status
            query = query.Include(r => r.RoomStatus);

            if (includeType)
            {
                query = query.Include(r => r.RoomType);
            }

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(r => r.RoomId == roomId);
        }

        public async Task<List<Room>> GetListAsync(bool includeType, bool trackEntity = true)
        {
            var query = this.dbContext.Room as IQueryable<Room>;

            // Always include the status
            query = query.Include(r => r.RoomStatus);

            if (includeType)
            {
                query = query.Include(r => r.RoomType);
            }

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<int> GetRoomCountByRoomTypeAsync(Guid roomTypeId)
        {
            return await this.dbContext.Room.CountAsync(r => r.RoomType!.RoomTypeId == roomTypeId);
        }

        public async Task UpdateAsync(Room room)
        {
            this.dbContext.Update(room);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int roomId, Enums.RoomStatus status)
        {
            await this.dbContext.Room
                .Where(r => r.RoomId == roomId)
                .ExecuteUpdateAsync(r => r.SetProperty(r => r.RoomStatusId, (int)status));
        }
    }
}
