using DTO.CategoryDTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    internal interface ISessionService
    {
        Task<(bool IsError, string ErrorMessage)> AddSession(int userId, string refreshToken);
        Task<(bool IsError, bool IsValid, string ErrorMessage)> CheckValidRefreshToken(int userId);
    }
}
