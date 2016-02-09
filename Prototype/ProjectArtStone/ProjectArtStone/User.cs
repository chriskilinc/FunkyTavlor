﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string id, string username, string password, string firstname, string lastname)
        {
            ID = id;
            Username = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
        }

        public User()
        {

        }
    }
}
