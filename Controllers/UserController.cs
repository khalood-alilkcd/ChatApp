using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Data.Models;
using ChatApp.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepositoryUser _User;
        private readonly IRepositoryManager<UserSender> _manager;

        public UserController(ILogger<UserController> logger, IRepositoryUser User, IRepositoryManager<UserSender> manager)
        {
            _manager = manager;
            _User = User;
            _logger = logger;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRoomAsync(int id)
        {
            var user = await _User.GetUser(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomsAsync()
        {
            var users = await _User.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserSender user)
        {
            await _User.CreateUser(user);
            await _manager.Save();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _User.GetUser(id);
            _User.DeleteUser(room);
            await _manager.Save();
            return Ok();
        }
    }
}