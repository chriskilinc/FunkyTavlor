﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
    public class DataManager
    {
        public static List<User> GetUsers()
        {
            var list = new List<User>()
            {
                new User() {ID="1", Username ="admin", Password="1234" },
                new User() {ID ="2", Username ="admin2", Password="1234"}
            };
            return list;
        }

        
        
    }



}
