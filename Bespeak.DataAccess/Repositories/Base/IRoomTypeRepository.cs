﻿using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomTypeRepository
    {
        Task<RoomType?> GetRoomTypeByIdAsync(string roomTypeId, bool trackEntity);

        Task<IEnumerable<RoomType>> GetRoomTypesAsync();

        Task AddAsync(RoomType roomType);

        Task<bool> IsRoomTypeExistsAsync(string typeName);
    }
}
