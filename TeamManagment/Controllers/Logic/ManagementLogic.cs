using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagment.Models;

namespace TeamManagment.Classes
{
    public class ManagmentLogic
    {
        private ApplicationDbContext context;

        public ManagmentLogic(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }


        public List<Player> getTeamPlayers(Team team)
        {
            return context.Players.Where(x => x.Team.Id == team.Id).ToList();
        }

        public List<Player> getAvailablePlayers()
        {
            return context.Players.Where(x => x.Team == null).ToList();
        }

        public bool removePlayerFromTeam(Player player)
        {
            if (player == null)
            {
                return false;
            }
            player.TeamId = null;
            context.SaveChanges();
            return true;
        }

        public void removeTeam(Team team)
        {
            List<Player> PlayersToRelease = context.Players.Where(player => player.Team.Id == team.Id).ToList();
            foreach (var player in PlayersToRelease)
            {
                player.Team = null;
                context.Entry(player).State = EntityState.Modified;
            }
            context.Teams.Remove(team);
            context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetAvailableTeams()
        {
            return context.Teams
                .Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() })
                .ToList();
        }

        public void AddPlayerToTeam(int playerId, int selectedTeamId)
        {
            context.Players.Find(playerId).TeamId = selectedTeamId;
            context.SaveChanges();
        }
    }
}