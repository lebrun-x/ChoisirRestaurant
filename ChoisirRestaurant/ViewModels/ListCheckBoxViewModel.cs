using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.ViewModels
{
    public class ListCheckBoxViewModel
    {
        public int Id { get; set; }
        public List<CheckBoxViewModel> ListCBV { get; set; }
    }
}