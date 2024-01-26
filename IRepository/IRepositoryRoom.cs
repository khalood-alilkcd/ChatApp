
using ChatApp.Data.Models;

namespace ChatApp.IRepository
{
    public interface IRepositoryRoom
    {
        Task<Room> GetRoom(int id);
        Task<IEnumerable<Room>> GetRooms();
        Task CreateRoom(Room room);
        void DeleteRoom(Room room);
    }
}