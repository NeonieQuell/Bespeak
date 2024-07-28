using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IReservationRepository
    {
        /// <summary>
        /// Retrieves an entity of Reservation using its ID
        /// </summary>
        /// <param name="reservationId">The ReservationId</param>
        /// <param name="includeRoom">Include the Reservation's related Room and its Type</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>Entity of Reservation</returns>
        Task<Reservation?> GetByIdAsync(int reservationId, bool includeRoom = true, bool trackEntity = true);

        /// <summary>
        /// Retrieves a list of Reservation
        /// </summary>
        /// <param name="includeRoom">Include the Reservations' related Room and its Type</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>List of Reservation</returns>
        Task<List<Reservation>> GetListAsync(bool includeRoom = true, bool trackEntity = true);

        /// <summary>
        /// Retrieves a list Reservation. Automatically includes the rooms' RoomType if includeRoom parameter is TRUE
        /// </summary>
        /// <param name="includeRoom">Include the Reservations' related Room and its Type</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>List of Reservation created within the past 7 days</returns>
        Task<List<Reservation>> GetRecentReservationsAsync(bool includeRoom = true, bool trackEntity = true);

        /// <summary>
        /// Checks if a reservation is available based on its start and end date
        /// </summary>
        /// <param name="reservation">The Reservation to be created</param>
        /// <returns>True or False</returns>
        Task<bool> IsAvailable(Reservation reservation);

        /// <summary>
        /// Adds the Reservation entity to the database
        /// </summary>
        /// <param name="reservation">The Reservation to be added</param>
        /// <returns></returns>
        Task AddAsync(Reservation reservation);

        /// <summary>
        /// Updates the Reservation entity in the database
        /// </summary>
        /// <param name="reservation">The Reservation to be updated</param>
        /// <returns></returns>
        Task UpdateAsync(Reservation reservation);

        /// <summary>
        /// Count the Reservations made based on RoomType
        /// </summary>
        /// <param name="roomTypeId">The RoomTypeId</param>
        /// <returns>Total Reservations made based on RoomType</returns>
        Task<int> GetReservationsCountByRoomTypeAsync(Guid roomTypeId);
    }
}
