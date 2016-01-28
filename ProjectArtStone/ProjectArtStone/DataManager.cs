using System;
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
                new User() {ID="1", Username ="admin", Password="1234", FirstName="Daniil", LastName ="Baykov" },
                new User() {ID ="2", Username ="chrissy", Password="1234", FirstName="Chris", LastName="Kilinc"},
                new User() {ID ="3", Username ="pete", Password="1234", FirstName="Peter", LastName="Heinum"}
            };
            return list;
        }

        
        
    }



}
