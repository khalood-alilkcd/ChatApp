using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Data.Models;

namespace ChatApp.IRepository
{
    public interface IRepositoryUser
    {
        Task<UserSender> GetUser(int id);
        Task<IEnumerable<UserSender>> GetUsers();
        Task CreateUser(UserSender user);
        void DeleteUser(UserSender user);
    }
}