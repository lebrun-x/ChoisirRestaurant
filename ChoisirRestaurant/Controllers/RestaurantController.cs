using ChoisirRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoisirRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            System.Collections.Generic.List<Resto> restau = new List<Resto>();
            restau = new Dal().ObtenirTousLesRestaurants();
            return View("Restaurant", restau);
        }

        public ActionResult ModifierRestaurant(int? id)
        {

            if (id.HasValue)
            {
                Dal dal = new Dal();
                Resto restau = dal.ObtenirTousLesRestaurants().Find(r => r.Id == id);
                return View("ModifierRestaurant", restau);
            }
            else
                return HttpNotFound();
        }

        public ActionResult AjouterRestaurant()
        {

            return View("AjouterRestaurant");
        }

        [HttpPost]
        public ActionResult AjouterRestaurant(Resto restau)
        {
            if (restau != null)
            {
                if (!ModelState.IsValid)
                    return View("AjouterRestaurant");
                else
                {
                    Dal dal = new Dal();
                    if (dal.RestaurantExiste(restau.Name))
                    {
                        ModelState.AddModelError("Name", "Ce nom de restaurant existe déjà");
                        return View("AjouterRestaurant");
                    }
                    dal.CreerNewRestaurant(restau.Name, restau.Telephone);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ModifierRestaurant(Resto restau)
        {
            if (restau != null)
            {
                if (!ModelState.IsValid)
                    return View("ModifierRestaurant");
                else
                {
                    Dal dal = new Dal();
                    /* if (dal.RestaurantExiste(restau.Name))
                     {
                         ModelState.AddModelError("Name", "Ce nom de restaurant existe déjà");
                         return View("ModifierRestaurant"); 
                     }*/
                    dal.ModifierRestaurant(restau.Id, restau.Name, restau.Telephone);
                }
            }
            return RedirectToAction("Index");
        }
    }
}