using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Session : Entity
    {
        public Session(int userId, string refreshToken)
        {
            UserId = userId;
            RefreshToken = refreshToken;
        }

        public int UserId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public virtual User User { get; set; }

    }
}
