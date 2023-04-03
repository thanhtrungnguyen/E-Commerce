using AutoMapper;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.UserDTO.Registration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Numerics;
using System.Security.Cryptography;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenRepository _tokenRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ITokenRepository tokenRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
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
                var passwordHashing = CreatePasswordHash(userRegistration.Password);
                user.PasswordHash = passwordHashing.Hashed;
                user.PasswordSalt = passwordHashing.Salt;
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
            var userExist = await _unitOfWork.Users.FindByUsernameAsync(username);
            if (!VerifyPasswordHash(password, userExist.PasswordHash, userExist.PasswordSalt))
            {
                return null;
            }
            return userExist;
        }
        private PasswordHashing CreatePasswordHash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return new PasswordHashing(salt, hashed);
        }

        private bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: passwordSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed == passwordHash;
        }

        public int GetUserIdFromToken(string token)
        {
            var decoded = _tokenRepository.DecodeJwtToken(token);
            return decoded.Id;
        }
    }
}
