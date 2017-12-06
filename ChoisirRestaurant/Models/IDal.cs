using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoisirRestaurant.Models
{
    interface IDal : IDisposable
    {
        List<Resto> ObtenirTousLesRestaurants();
        void CreerNewRestaurant(String nom, String telephone);
        void ModifierRestaurant(int id, String name, String telephone);
        bool RestaurantExiste(String name);
        Utilisateur ObtenirUtilisateur(int id);
        int AjouterUtilisateur(String name, String password);
        Utilisateur Authentifier(String name, String password);
        int CreerUnSondage();
        bool ADejaVote(int idsondage, String utilisateur);
        void AjouterVote(int idSondage, int resto, int idUtilisateur);
        List<Resultats> ObtenirLesResultats(int idSondage);
    }
}
