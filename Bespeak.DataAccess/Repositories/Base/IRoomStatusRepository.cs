using Entities = Bespeak.Entity.Entities;
using Enums = Bespeak.Constants.Enums;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomStatusRepository
    {
        /// <summary>
        /// Retrieves an entity of RoomStatus using its ID
        /// </summary>
        /// <param name="status">The RoomStatusID</param>
        /// <returns>Entity of RoomStatus</returns>
        Task<Entities.RoomStatus?> GetByIdAsync(int status);

        /// <summary>
        /// Retrieves an entity of RoomStatus using enum
        /// </summary>
        /// <param name="status">The enum of RoomStatus</param>
        /// <returns>Entity of RoomStatus</returns>
        Task<Entities.RoomStatus?> GetByIdAsync(Enums.RoomStatus status);

        /// <summary>
        /// Retrieves the Name of the RoomStatus using its ID
        /// </summary>
        /// <param name="status">The RoomStatusID</param>
        /// <returns>string</returns>
        Task<string?> GetNameAsync(int status);

        /// <summary>
        /// Retrieves the Name of the RoomStatus using enum
        /// </summary>
        /// <param name="status">The enum of RoomStatus</param>
        /// <returns>string</returns>
        Task<string?> GetNameAsync(Enums.RoomStatus status);
    }
}
