using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomTypeRepository
    {
        /// <summary>
        /// Retrieves an entity of RoomType using its ID
        /// </summary>
        /// <param name="roomTypeId">The RoomTypeId</param>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>Entity of RoomType</returns>
        Task<RoomType?> GetByIdAsync(Guid roomTypeId, bool trackEntity = true);

        /// <summary>
        /// Retrieves a list of RoomType
        /// </summary>
        /// <param name="trackEntity">Specifies if the entity needs to be tracked by the DbContext</param>
        /// <returns>List of RoomType</returns>
        Task<List<RoomType>> GetListAsync(bool trackEntity = true);

        /// <summary>
        /// Adds the RoomType entity to the database
        /// </summary>
        /// <param name="roomType">The RoomType to be added</param>
        /// <returns></returns>
        Task AddAsync(RoomType roomType);

        /// <summary>
        /// Checks if a RoomType exists based on its Name
        /// </summary>
        /// <param name="name">The RoomType's Name</param>
        /// <returns>True or False</returns>
        Task<bool> IsRoomTypeExistsAsync(string name);

        /// <summary>
        /// Updates the RoomType entity in the database
        /// </summary>
        /// <param name="roomType">The RoomType to be updated</param>
        /// <returns></returns>
        Task UpdateAsync(RoomType roomType);
    }
}
