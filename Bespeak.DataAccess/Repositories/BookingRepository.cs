﻿using Bespeak.DataAccess.Context;
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

        public async Task AddAsync(Reservation booking)
        {
            var count = Convert.ToString(await _dbContext.Bookings.CountAsync() + 1);
            booking.ReservationId = $"BK{count}";
            booking.CreateDate = DateTime.Now;

            // Change status of booked room
            await _roomRepository.UpdateStatusAsync(booking.RoomId, "Occupied");

            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Reservation?> GetBookingByIdAsync(string bookingId, bool trackEntity)
        {
            var bookings = _dbContext.Bookings as IQueryable<Reservation>;

            if (!trackEntity)
                bookings = bookings.AsNoTracking();

            return await bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .FirstOrDefaultAsync(b => b.ReservationId == bookingId);
        }

        public async Task<IEnumerable<Reservation>> GetBookingsAsync()
        {
            return await _dbContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetRecentBookingsAsync()
        {
            return await _dbContext.Bookings
                .Where(b => b.CreateDate > DateTime.Now.AddDays(-7))
                .Include(b => b.Room)
                .ThenInclude(r => r!.RoomType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetBookingsCountByRoomTypeAsync(string typeName)
        {
            return await _dbContext.Bookings.CountAsync(b => b.Room!.RoomType!.Name == typeName);
        }

        public async Task UpdateAsync(Reservation booking)
        {
            _dbContext.Update(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsAvailable(Reservation booking)
        {
            bool isAvailable = await _dbContext.Bookings.AnyAsync(b => (b.RoomId == booking.RoomId)
                && ((booking.StartDate >= b.StartDate && booking.StartDate <= b.EndDate)
                || (booking.EndDate >= b.StartDate && booking.EndDate <= b.EndDate)));

            return !isAvailable;
        }
    }
}
