using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
   public class Account
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account(string id, string username, string password)
        {
            ID = id;
            Username = username;
            Password = password;
        }
    }

    public Account()
    {

    }
}
