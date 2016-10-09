using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamManagment.Models
{
    public class Player
    {
        public Team team { get; set; }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}