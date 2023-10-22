using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BespeakDbContext _dbContext;
        private readonly IRoomRepository _roomRepository;

        #region Constructor
        public BookingRepository(
            BespeakDbContext dbContext,
            IRoomRepository roomRepository)
        {
            _dbContext = dbContext;
            _roomRepository = roomRepository;
        }
        #endregion

        public async Task AddAsync(Booking booking)
        {
            var count = Convert.ToString(await _dbContext.Bookings.CountAsync() + 1);
            booking.BookingId = $"BK{count}";
            booking.DateBooked = DateTime.Now;

            // Change status of booked room
            await _roomRepository.UpdateStatusAsync(booking.RoomId, "Occupied");

            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(string bookingId)
        {
            return await _dbContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _dbContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetRecentBookingsAsync()
        {
            return await _dbContext.Bookings
                .Where(b => b.DateBooked > DateTime.Now.AddDays(-7))
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .ToListAsync();
        }

        public async Task<int> GetBookingsCountByRoomTypeAsync(string typeName)
        {
            return await _dbContext.Bookings.CountAsync(b => b.Room!.RoomType!.TypeName == typeName);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _dbContext.Update(booking);
            await _dbContext.SaveChangesAsync();
        }
    }
}
