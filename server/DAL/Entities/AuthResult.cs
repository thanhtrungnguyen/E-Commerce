using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Errors { get; set; }
    }
}
