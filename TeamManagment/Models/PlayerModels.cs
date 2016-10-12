using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagment.Models
{
    public class Player
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Height { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}