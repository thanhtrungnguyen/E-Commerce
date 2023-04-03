using AutoMapper;
using BLL.Abstractions;
using DAL.Abstractions;
using DAL.Entities;
using DTO.CategoryDTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(bool IsError, string ErrorMessage)> AddSession(int userId, string refreshToken)
        {
            try
            {
                await _unitOfWork.Sessions.Add(new DAL.Entities.Session(userId, refreshToken));
                return (false, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public async Task<(bool IsError, bool IsValid, string ErrorMessage)> CheckValidRefreshToken(int userId)
        {
            try
            {
                var session = await _unitOfWork.Sessions.GetLatestSession(userId);
                bool isValid = session.RefreshToken == "";
                return (false, false, string.Empty);
            }
            catch (Exception ex)
            {
                return (true, false, ex.Message);
            }
        }
    }
}
