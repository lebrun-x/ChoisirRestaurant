using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.ViewModels
{
    public class CheckBoxViewModel
    {
        public int Idbox { get; set; }
        public bool IsCheck { get; set; }
        public String RestauName { get; set; }
    }
}