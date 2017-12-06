using ChoisirRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChoisirRestaurant
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IDatabaseInitializer<BddContext> init = new InitChoixResto();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());  
        }
    }
}
