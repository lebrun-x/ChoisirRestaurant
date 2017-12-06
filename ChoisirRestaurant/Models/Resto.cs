using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.Models
{
    [Table("Resto")]
    public class Resto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom du restaurant doit être saisi")]
        public String Name { get; set; }
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Caractères invalides")]
        public String Telephone { get; set; }
    }

}