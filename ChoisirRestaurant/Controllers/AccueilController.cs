using ChoisirRestaurant.Models;
using ChoisirRestaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoisirRestaurant.Controllers
{
    public class AccueilController : Controller
    {
        IDal dal;
        // GET: Accueil
        public ActionResult Index()
        {
           // AccueilViewModel accueil = new AccueilViewModel
           // {
           //     Message = "Bienvenue sur cette page",
           //     Date = DateTime.Now,
           //     Restau = new Resto { Name = "Fourchette", Telephone = "1234567890" },
           //     ListResto = new List<Resto>
           //     {
           //         new Resto {Name = "Couteau", Telephone = "99999999"},
           //         new Resto {Name = "Cuillère", Telephone = "987654321"},
           //         new Resto {Name = "Verre", Telephone = "11112222"}
           //     }
           // };
           // accueil.ListResto.Add(accueil.Restau);
           // ViewBag.ListResto = new SelectList(accueil.ListResto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost()
        {
            dal = new Dal();
            int idSondage = dal.CreerUnSondage(); 
            return RedirectToAction("Index", "Sondage", new { id = idSondage });
        }
    }
}
