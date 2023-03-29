using DAL.Entities;
using DTO.UserDTO.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>?> GetUsersPagination(int page, int numberOfUsers);
        Task<User?> GetUser(int id);
        Task<(bool IsError, string ErrorMessage)> AddUser(UserRegistrationRequest userRegistration);
        Task<(bool IsError, string ErrorMessage)> UpdateUser(User user);

        Task<bool> CheckExistEmail(string email);

        Task<bool> CheckExistPhone(string phone);
        Task<bool> CheckExistUsername(string username);
        Task<bool> CheckExistUsernameAndPassword(string username, string password);
    }
}
