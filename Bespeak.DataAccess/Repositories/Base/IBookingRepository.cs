using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IBookingRepository
    {
        Task<Booking?> GetBookingByIdAsync(string bookingId);

        Task<IEnumerable<Booking>> GetBookingsAsync();

        Task<string> AddAsync(Booking booking);

        Task<int> GetBookingsCountByRoomTypeAsync(string typeName);
    }
}
