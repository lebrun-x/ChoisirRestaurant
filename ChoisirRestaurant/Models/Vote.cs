using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Resto _resto { get; set; }
        public virtual Utilisateur _user { get; set; }
    }
}