using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserPaymentRepository : GenericRepository<UserPayment>, IUserPaymentRepository
    {
        public UserPaymentRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
