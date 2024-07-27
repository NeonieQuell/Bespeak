using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IBookingRepository
    {
        Task<Booking?> GetBookingByIdAsync(string bookingId, bool trackEntity);

        Task<IEnumerable<Booking>> GetBookingsAsync();

        Task<IEnumerable<Booking>> GetRecentBookingsAsync();

        Task<bool> IsAvailable(Booking booking);

        Task AddAsync(Booking booking);

        Task UpdateAsync(Booking booking);

        Task<int> GetBookingsCountByRoomTypeAsync(string typeName);
    }
}
