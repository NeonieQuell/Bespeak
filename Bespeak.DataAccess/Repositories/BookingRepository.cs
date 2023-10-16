using Bespeak.DataAccess.Context;
using Bespeak.DataAccess.Repositories.Base;
using Bespeak.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BespeakDbContext _dbContext;

        public BookingRepository(BespeakDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddAsync(Booking booking)
        {
            var count = Convert.ToString(await _dbContext.Bookings.CountAsync() + 1);
            booking.BookingId = $"BK{count}";

            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();

            return booking.BookingId;
        }

        public async Task<Booking?> GetBookingByIdAsync(string bookingId)
        {
            return await _dbContext.Bookings.FindAsync(bookingId);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _dbContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .ToListAsync();
        }

        public async Task<int> GetBookingsCountByRoomTypeAsync(string typeName)
        {
            return await _dbContext.Bookings.CountAsync(b => b.Room!.RoomType!.TypeName == typeName);
        }
    }
}
