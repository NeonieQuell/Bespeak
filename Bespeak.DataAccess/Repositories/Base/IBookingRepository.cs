using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IBookingRepository
    {
        Task<Reservation?> GetBookingByIdAsync(string bookingId, bool trackEntity);

        Task<IEnumerable<Reservation>> GetBookingsAsync();

        Task<IEnumerable<Reservation>> GetRecentBookingsAsync();

        Task<bool> IsAvailable(Reservation booking);

        Task AddAsync(Reservation booking);

        Task UpdateAsync(Reservation booking);

        Task<int> GetBookingsCountByRoomTypeAsync(string typeName);
    }
}
