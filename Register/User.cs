using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    internal class User
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Phonenumber { get; set; }
        public string Pasword { get; set; }
        public Dictionary<string, StreamReader> UserList = new Dictionary<string, StreamReader>();
    }
}
