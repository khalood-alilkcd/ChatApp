
using ChatApp.Data;
using ChatApp.Data.Models;
using ChatApp.IRepository;

namespace ChatApp.Repository
{
    public class RepositoryMessages : RepositoryManager<Message>, IRepositoryMassages
    {
        public RepositoryMessages(AppDbContext context) : base(context)
        {
        }

        public async Task<Message> GetMessage(int id)
        {
            var msg = await GetById(id);
            return msg;
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            var msgs = await GetAll();
            return msgs;
        }

        public async Task CreateMessage(Message msg)
        {
            await Create(msg);
        }

        public void DeleteMessage(Message msg)
        {
            Delete(msg);
        }
    }
}