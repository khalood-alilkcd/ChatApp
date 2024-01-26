
using ChatApp.Data;
using ChatApp.Data.Models;
using ChatApp.IRepository;

namespace ChatApp.Repository
{
    public class RepositoryUser : RepositoryManager<UserSender>, IRepositoryUser
    {
        public RepositoryUser(AppDbContext context) : base(context)
        {
        }


        public async Task<UserSender> GetUser(int id)
        {
            var user = await GetById(id);
            return user;
        }

        public async Task<IEnumerable<UserSender>> GetUsers()
        {
            var users = await GetAll();
            return users;
        }

        public async Task CreateUser(UserSender user)
        {
            await Create(user);
        }

        public void DeleteUser(UserSender user)
        {
            Delete(user);
        }
    }
}