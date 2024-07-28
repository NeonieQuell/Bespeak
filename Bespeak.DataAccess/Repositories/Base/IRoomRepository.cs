using Entities = Bespeak.Entity.Entities;
using Enums = Bespeak.Constants.Enums;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Retrieves an entity of Room using its ID
        /// </summary>
        /// <param name="roomId">The RoomId</param>
        /// <param name="includeType">Include the Room's Type</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>Entity of Room</returns>
        Task<Entities.Room?> GetByIdAsync(Guid roomId, bool includeType, bool trackEntity = true);

        /// <summary>
        /// Retrieves a list of Room
        /// </summary>
        /// <param name="includeType">Include the Rooms' Type</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>List of Rooms</returns>
        Task<List<Entities.Room>> GetListAsync(bool includeType, bool trackEntity = true);

        /// <summary>
        /// Adds the Room entity to the database
        /// </summary>
        /// <param name="room">The Room to be added</param>
        /// <returns></returns>
        Task AddAsync(Entities.Room room);

        /// <summary>
        /// Count the total Rooms and the Rooms based on its status
        /// </summary>
        /// <returns>Total count of all the Rooms, and the available and occupied Rooms</returns>
        Task<(int total, int available, int occupied)> GetAllCountsAsync();

        /// <summary>
        /// Count the Rooms based on its Type
        /// </summary>
        /// <param name="roomTypeId">The RoomTypeId</param>
        /// <returns>Total count of Rooms based on its Type</returns>
        Task<int> GetRoomCountByRoomTypeAsync(Guid roomTypeId);

        /// <summary>
        /// Updates the status of the Room in the database
        /// </summary>
        /// <param name="roomId">The RoomId</param>
        /// <param name="status">The Room's status</param>
        /// <returns></returns>
        Task UpdateStatusAsync(Guid roomId, Enums.RoomStatus status);
    }
}
