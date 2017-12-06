using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.Models
{
    public class Utilisateur
    {
        [Required, MaxLength(20)]
        public String Name { get; set; }
        public String Password { get; set; }
        public int Id { get; set; }
    }
}