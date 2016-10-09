using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManagment.Models;

namespace TeamManagment.Classes
{
    public class ManagmentLogic
    {
        public ICollection<Player> players { get; set; }
        public ICollection<Team> teams { get; set; }

        public ManagmentLogic(ApplicationDbContext ctx) {
            if (teams.Count == 0) {
                Team freePLayers = new Team(freePLayers.Id = 0,freePLayers.Name = "Free players", freePLayers.Players = null);
                teams.Add(new Team(N))
            }
        }

        public void removePlayer(Player playerToRemove) {
            players.Remove(x => x.  );
        }
    }
}