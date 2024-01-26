using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Data.Models;
using ChatApp.IRepository;
using ChatApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IRepositoryMassages _msg;
        private readonly IRepositoryManager<Message> _manager;

        public MessageController(
            ILogger<MessageController> logger,
            IRepositoryMassages msg,
            IRepositoryManager<Message> manager
            )
        {
            _manager = manager;
            _msg = msg;
            _logger = logger;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMessageAsync(int id)
        {
            var msg = await _msg.GetMessage(id);
            return Ok(msg);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesAsync()
        {
            var msgs = await _msg.GetMessages();
            return Ok(msgs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(Message msg)
        {
            await _msg.CreateMessage(msg);
            await _manager.Save();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var msg = await _msg.GetMessage(id);
            _msg.DeleteMessage(msg);
            await _manager.Save();
            return Ok();
        }
    }
}