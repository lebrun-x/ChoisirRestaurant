using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoisirRestaurant.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;
        private MD5 md5hash;

        public Dal()
        {
            bdd = new BddContext();
        }

        public void CreerNewRestaurant(String nom, String telephone)
        {
            bdd.Restos.Add(new Resto { Name = nom, Telephone = telephone });
            bdd.SaveChanges();
        }
     
        public void ModifierRestaurant(int id, String name, String telephone)
        {
            Resto changeResto = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (changeResto != null)
            {
                changeResto.Name = name;
                changeResto.Telephone = telephone;
                bdd.SaveChanges();
            }
        }
     
        public bool RestaurantExiste(String name)
        {
            Resto restoExiste = bdd.Restos.FirstOrDefault(resto => resto.Name == name);
            return restoExiste != null;
        }
     
        public int AjouterUtilisateur(String name, String password)
        {
            md5hash = MD5.Create();
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.Name = name;
            utilisateur.Password = GetMd5Hash(md5hash, password);
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return Authentifier(name, password).Id;
        }
     
        public Utilisateur Authentifier(String name, String password)
        {
            Utilisateur utilisateur = bdd.Utilisateurs.FirstOrDefault(users => users.Name == name);
            if (utilisateur != null && VerifyMd5Hash(md5hash, password, utilisateur.Password))
                return utilisateur;
            else
                return null;
        }
     
        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(users => users.Id == id);
        }
     
        public int CreerUnSondage()
        {
            Sondage sondage = new Sondage();
            DateTime date = DateTime.Now;
            String sdate = String.Format("{0:dd/MM/yyyy}", date);
            date = DateTime.Parse(sdate);
            List <Vote> votes = new List<Vote>();
            sondage.Date = date;
            sondage.Votes = votes;
            bdd.Sondages.Add(sondage);
            bdd.SaveChanges();
            return sondage.Id;
        }

        public bool ADejaVote(int idsondage, String utilisateur)
        {
            Sondage sondage = new Sondage();
            sondage = bdd.Sondages.FirstOrDefault(sondages => sondages.Id == idsondage);
            if (sondage != null)
            {
                for (int i = 0; i < sondage.Votes.Count; i++)
                {
                    if (sondage.Votes[i]._user.Id.ToString() == utilisateur)
                        return true;
                }
            }
            return false;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote();
            Utilisateur utilisateur = bdd.Utilisateurs.FirstOrDefault(users => users.Id == idUtilisateur);
            Resto restau = bdd.Restos.FirstOrDefault(resto => resto.Id == idResto);
            Sondage sondageActuel = bdd.Sondages.FirstOrDefault(sondage => sondage.Id == idSondage);
            vote._resto = restau;
            vote._user = utilisateur;
            if (sondageActuel != null)
                sondageActuel.Votes.Add(vote);
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            Sondage sondageActuel = bdd.Sondages.FirstOrDefault(sondage => sondage.Id == idSondage);
            List<Resultats> listResultats = new List<Resultats>();
            if (sondageActuel != null)
            {
                for (int i = 0; i < sondageActuel.Votes.Count; i++)
                {
                    if (listResultats.FindIndex(result => result.Nom.Equals(sondageActuel.Votes[i]._resto.Name)) == -1 )
                    {
                        Resultats result = new Resultats();
                        result.Nom = sondageActuel.Votes[i]._resto.Name;
                        result.Telephone = sondageActuel.Votes[i]._resto.Telephone;
                        result.NombreDeVotes = 1;
                        listResultats.Add(result);
                    }
                    else
                    {
                        listResultats[listResultats.FindIndex(result => result.Nom.Equals(sondageActuel.Votes[i]._resto.Name))].NombreDeVotes++;
                    }
                }
            }
            return listResultats;
        }
     
        public List<Resto> ObtenirTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }
        
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}