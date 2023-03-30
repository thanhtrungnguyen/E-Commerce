using AutoMapper;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.UserDTO.Registration;
using System.Numerics;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<bool> CheckExistEmail(string email)
        {
            var userExist = await _unitOfWork.Users.FindByEmailAsync(email);
            if (userExist != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckExistPhone(string phone)
        {
            var userExist = await _unitOfWork.Users.FindByPhoneAsync(phone);
            if (userExist != null)
            {
                return true;
            }
            return false;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>?> GetUsersPagination(int page, int numberOfUsers)
        {
            throw new NotImplementedException();
        }


        public async Task<(bool IsError, string ErrorMessage)> AddUser(UserRegistrationRequest userRegistration)
        {
            try
            {
                User user = _mapper.Map<User>(userRegistration);
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();
                return (false, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }

        }

        public Task<(bool IsError, string ErrorMessage)> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckExistUsername(string username)
        {
            var userExist = await _unitOfWork.Users.FindByUsernameAsync(username);
            if (userExist != null)
            {
                return true;
            }
            return false;
        }

        public async Task<User>? CheckExistUsernameAndPassword(string username, string password)
        {
            var userExist = await _unitOfWork.Users.FindByUsernameAndPasswordAsync(username, password);
            return userExist;
        }

    }
}
