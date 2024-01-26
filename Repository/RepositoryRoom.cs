
using ChatApp.Data;
using ChatApp.Data.Models;
using ChatApp.IRepository;

namespace ChatApp.Repository
{
    public class RepositoryRoom : RepositoryManager<Room>, IRepositoryRoom
    {
        public RepositoryRoom(AppDbContext context) : base(context)
        {
        }

        public async Task<Room> GetRoom(int id)
        {
            var room = await GetById(id);
            return room;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var rooms = await GetAll();
            return rooms;
        }

        public async Task CreateRoom(Room room)
        {
            await Create(room);
        }

        public void DeleteRoom(Room room)
        {
            Delete(room);
        }
    }
}