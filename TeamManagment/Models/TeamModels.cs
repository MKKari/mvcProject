using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamManagment.Models
{
    public class Team
    {
        
        public int Id { get; set; }

        [Required]
        //[Remote("IsTeamNameAvailable", "Teams", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }

    }

    public class ShowTeamsViewModel
    {
        public int PlayerId { get; set; }
        public int SelectedTeamId { get; set; }

        [Display(Name = "Choose team")]
        public IEnumerable<SelectListItem> Teams { get; set; }
    }

    public class TeamIndexModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Player> AvailablePlayers { get; set; }
    }
}