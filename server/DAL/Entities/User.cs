using DAL.Enums;
using DAL.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isActivite { get; set; }
        public string VerifyCode { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Avatar { get; set; }
    }
}
