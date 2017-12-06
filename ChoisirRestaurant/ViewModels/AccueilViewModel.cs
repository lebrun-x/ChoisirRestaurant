using ChoisirRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.ViewModels
{
    public class AccueilViewModel
    {
        public String Message { get; set; }
        public DateTime Date { get; set; }
        public Resto Restau { get; set; }
        public List<Resto> ListResto { get; set; }
        public String Login { get; set; }
        public String Mdp { get; set; }
    }
}