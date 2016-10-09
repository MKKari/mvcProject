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
        public Team freePLayers;

        public ManagmentLogic(ApplicationDbContext dbCtx) {
            players = dbCtx.Players.ToList();
            teams = dbCtx.Teams.ToList();

            if (teams.Count == 0) {
                freePLayers = new Team(0,"Free players",new List<Player>());
                teams.Add(freePLayers);
                dbCtx.Teams.Add(freePLayers);
                dbCtx.SaveChanges();
            }
        }

        public void addNewFreePlayer(Player newPlayer, Team team) {
            if (team == null)
            {
                newPlayer.team = freePLayers;
                freePLayers.Players.Add(newPlayer);
            }
            else
            {
                newPlayer.team = team;
                team.Players.Add(newPlayer);
            }
       
        }

        public void removePlayer(Player playerToRemove) {
            playerToRemove.team.Players.Remove(playerToRemove);
            players.Remove(playerToRemove);           
        }
    }
}