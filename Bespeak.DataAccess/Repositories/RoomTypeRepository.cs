using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly BespeakDbContext dbContext;

        public RoomTypeRepository(BespeakDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(RoomType roomType)
        {
            roomType.RoomTypeId = Guid.NewGuid();

            await this.dbContext.RoomType.AddAsync(roomType);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<RoomType?> GetByIdAsync(Guid roomTypeId, bool trackEntity = true)
        {
            var query = this.dbContext.RoomType as IQueryable<RoomType>;

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(rt => rt.RoomTypeId == roomTypeId);
        }

        public async Task<List<RoomType>> GetListAsync(bool trackEntity = true)
        {
            var query = this.dbContext.RoomType as IQueryable<RoomType>;

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<bool> IsRoomTypeExistsAsync(string name)
        {
            return await this.dbContext.RoomType.AnyAsync(rt => rt.Name.ToLower() == name.ToLower());
        }

        public async Task UpdateAsync(RoomType roomType)
        {
            this.dbContext.Update(roomType);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
