
using ChatApp.Data.Models;

namespace ChatApp.IRepository
{
    public interface IRepositoryMassages
    {
        Task<Message> GetMessage(int id);
        Task<IEnumerable<Message>> GetMessages();
        Task CreateMessage(Message msg);
        void DeleteMessage(Message msg);
    }
}