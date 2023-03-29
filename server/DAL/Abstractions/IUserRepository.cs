using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface IUserRepository : IGenereicRepository<User>
    {
        Task<User>? FindByEmailAsync(string email);
        Task<User>? FindByPhoneAsync(string phone);
        Task<User>? FindByUsernameAsync(string username);
        Task<User>? FindByUsernameAndPasswordAsync(string username, string password);
    }
}
