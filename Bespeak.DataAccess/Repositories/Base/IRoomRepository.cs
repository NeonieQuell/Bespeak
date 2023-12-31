﻿using Bespeak.Entity.Entities;

namespace Bespeak.DataAccess.Repositories.Base
{
    public interface IRoomRepository
    {
        Task<Room?> GetRoomByIdAsync(string roomId, bool trackEntity);

        Task<IEnumerable<Room>> GetRoomsAsync();

        Task AddAsync(Room room);

        Task<(int total, int available, int occupied)> GetRoomsCountAsync();

        Task<int> GetRoomsCountByRoomTypeAsync(string typeName);

        Task UpdateStatusAsync(string roomId, string status);
    }
}
