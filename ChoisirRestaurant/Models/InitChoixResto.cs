using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChoisirRestaurant.Models
{
    public class InitChoixResto : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Restos.Add(new Resto { Id = 4, Name = "Resto pinambour", Telephone = "0102030405" });
            context.Restos.Add(new Resto { Id = 2, Name = "Resto pinière", Telephone = "0102030405" });
            context.Restos.Add(new Resto { Id = 3, Name = "Resto toro", Telephone = "0102030405" });
            
            base.Seed(context);
        }
    }
}