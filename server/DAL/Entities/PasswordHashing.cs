using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PasswordHashing
    {
        public byte[] Salt { get; set; }
        public string Hashed { get; set; }
        public PasswordHashing(byte[] salt, string hashed)
        {
            Salt = salt;
            Hashed = hashed;
        }
    }
}
