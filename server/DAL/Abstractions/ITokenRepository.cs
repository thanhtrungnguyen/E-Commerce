using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstractions
{
    public interface ITokenRepository
    {
        string CreateJwtToken(User user);
        User DecodeJwtToken(string jwtToken);
    }
}
