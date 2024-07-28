using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = Bespeak.Constants.Enums;

namespace Bespeak.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BespeakDbContext dbContext;
        private readonly IRoomRepository roomRepository;

        public ReservationRepository(BespeakDbContext dbContext, IRoomRepository roomRepository)
        {
            this.dbContext = dbContext;
            this.roomRepository = roomRepository;
        }

        public async Task AddAsync(Reservation reservation)
        {
            reservation.CreateDate = DateTime.Now;

            // Change status of room to occupied
            await this.roomRepository.UpdateStatusAsync(reservation.RoomId, Enums.RoomStatus.Occupied);

            await this.dbContext.Reservation.AddAsync(reservation);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int reservationId, bool includeRoom = true, bool trackEntity = true)
        {
            var query = this.dbContext.Reservation as IQueryable<Reservation>;

            if (includeRoom)
            {
                query = query.Include(r => r.Room).ThenInclude(r => r!.RoomType);
            }

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }

        public async Task<List<Reservation>> GetListAsync(bool includeRoom = true, bool trackEntity = true)
        {
            var query = this.dbContext.Reservation as IQueryable<Reservation>;

            if (includeRoom)
            {
                query = query.Include(r => r.Room).ThenInclude(r => r!.RoomType);
            }

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<List<Reservation>> GetRecentReservationsAsync(bool includeRoom = true, bool trackEntity = true)
        {
            var query = this.dbContext.Reservation as IQueryable<Reservation>;

            if (includeRoom)
            {
                query = query.Include(r => r.Room).ThenInclude(r => r!.RoomType);
            }

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return await query.Where(r => r.CreateDate > DateTime.Now.AddDays(-7)).ToListAsync();
        }

        public async Task<int> GetReservationsCountByRoomTypeAsync(Guid roomTypeId)
        {
            return await this.dbContext.Reservation.CountAsync(r => r.Room!.RoomTypeId == roomTypeId);
        }

        public async Task<bool> IsAvailable(Reservation reservation)
        {
            bool result = await this.dbContext.Reservation.AnyAsync(r => (r.RoomId == reservation.RoomId)
                && ((reservation.StartDate >= r.StartDate && reservation.StartDate <= r.EndDate)
                || (reservation.EndDate >= r.StartDate && reservation.EndDate <= r.EndDate)));

            return !result;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            this.dbContext.Update(reservation);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
