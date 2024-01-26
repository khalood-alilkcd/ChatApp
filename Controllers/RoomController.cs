
using ChatApp.Data.Models;
using ChatApp.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRepositoryRoom _room;
        private readonly IRepositoryManager<Room> _manager;

        public RoomController(ILogger<RoomController> logger, IRepositoryRoom room, IRepositoryManager<Room> manager)
        {
            _manager = manager;
            _room = room;
            _logger = logger;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRoomAsync(int id)
        {
            var room = await _room.GetRoom(id);
            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomsAsync()
        {
            var rooms = await _room.GetRooms();
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync(Room room)
        {
            await _room.CreateRoom(room);
            await _manager.Save();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _room.GetRoom(id);
            _room.DeleteRoom(room);
            await _manager.Save();
            return Ok();
        }
    }
}