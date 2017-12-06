using ChoisirRestaurant.Models;
using ChoisirRestaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoisirRestaurant.Controllers
{
    public class SondageController : Controller
    {
        ListCheckBoxViewModel listCBV; 
        // GET: Sondage
        public ActionResult Index(int id)
        {
            IDal dal = new Dal();
            List<Resto> listResto = new List<Resto>();
            listResto = dal.ObtenirTousLesRestaurants();
            listCBV = new ListCheckBoxViewModel();
            for(int i = 0; i < listResto.Count; i++)
            {
                listCBV.ListCBV.Add(new CheckBoxViewModel { Idbox = i, IsCheck = false, RestauName = listResto[i].Name });
            }
            ViewBag.IdSondage = id;
            return View("Index", listResto);
        }

        public ActionResult Vote(int id)
        {

            IDal dal = new Dal();
            List<Resto> listResto = new List<Resto>();
            listResto = dal.ObtenirTousLesRestaurants();
            foreach(var restau in listResto)
            {

            }
            //dal.AjouterVote(id)
            return RedirectToAction("Resultat");
        }
    }
}