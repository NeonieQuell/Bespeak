using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Entities = Bespeak.Entity.Entities;
using Enums = Bespeak.Constants.Enums;

namespace Bespeak.DataAccess.Repositories
{
    public class RoomStatusRepository : IRoomStatusRepository
    {
        private readonly BespeakDbContext dbContext;

        public RoomStatusRepository(BespeakDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Entities.RoomStatus?> GetByIdAsync(int status)
        {
            return await dbContext.RoomStatus.FirstOrDefaultAsync(rs => rs.RoomStatusId == status);
        }

        public async Task<Entities.RoomStatus?> GetByIdAsync(Enums.RoomStatus status)
        {
            return await dbContext.RoomStatus.FirstOrDefaultAsync(rs => rs.RoomStatusId == (int)status);
        }

        public async Task<string?> GetNameAsync(int status)
        {
            return await dbContext.RoomStatus
                .Where(rs => rs.RoomStatusId == status)
                .Select(rs => rs.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetNameAsync(Enums.RoomStatus status)
        {
            return await dbContext.RoomStatus
                .Where(rs => rs.RoomStatusId == (int)status)
                .Select(rs => rs.Name)
                .FirstOrDefaultAsync();
        }
    }
}
