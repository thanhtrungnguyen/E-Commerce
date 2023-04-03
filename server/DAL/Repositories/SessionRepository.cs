using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Session>? GetLatestSession(int userId)
        {
            return await _context.Sessions
                .AsNoTracking()
                .OrderByDescending(s => s.CreatedTime)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
