using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamManagment.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }

        public Team(int id, string name, ICollection<Player> players)
        {
            this.Id = id;
            this.Name = name;
            this.Players = players;
        }
    }
}