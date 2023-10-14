using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly BespeakDbContext _dbContext;

        public RoomTypeRepository(BespeakDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(RoomType roomType)
        {
            string count = Convert.ToString(await _dbContext.RoomTypes.CountAsync() + 1);
            roomType.RoomTypeId = $"RMTYPE{count}";

            await _dbContext.RoomTypes.AddAsync(roomType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RoomType?> GetRoomTypeByIdAsync(string roomTypeId)
        {
            return await _dbContext.RoomTypes.FindAsync(roomTypeId);
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypesAsync()
        {
            return await _dbContext.RoomTypes.ToListAsync();
        }

        public async Task<bool> IsRoomTypeExistsAsync(string typeName)
        {
            return await _dbContext.RoomTypes.AnyAsync(rt =>
                rt.TypeName.ToLower() == typeName.ToLower());
        }
    }
}
