using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.SqlClient;

namespace Evaluation.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Client> ObtientTousLesClients()
        {
            return bdd.Clients.ToList();
        }

        public void CreerClient(string nom, string prenom, string adresse, string ville)
        {
            bdd.Clients.Add(new Client { Nom = nom, Prenom = prenom, Adresse = adresse, Ville = ville });
            bdd.SaveChanges();
        }

        public void SupprimerClient(int id, string nom, string prenom, string adresse, string ville)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.Id == id);
            if (ClientTrouve != null)
            {
                bdd.Clients.Remove(ClientTrouve);
                bdd.SaveChanges();
            }
        }

        public void ModifierClient(int id, string nom, string prenom, string adresse, string ville)
        {
            Client ClientTrouve = bdd.Clients.FirstOrDefault(client => client.Id == id);
            if (ClientTrouve != null)
            {
                ClientTrouve.Nom = nom;
                ClientTrouve.Prenom = prenom;
                ClientTrouve.Adresse = adresse;
                ClientTrouve.Ville = ville;
                bdd.SaveChanges();
            }
        }
        
        public bool ClientExiste(string nom, string prenom)
        {
            return bdd.Clients.Any(client => (string.Compare(client.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0)
            && (string.Compare(client.Prenom, prenom, StringComparison.CurrentCultureIgnoreCase) == 0));
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}