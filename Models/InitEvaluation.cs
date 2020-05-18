using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Data.SqlClient;

namespace Evaluation.Models
{
    public class InitEvaluation : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Clients.Add(new Client { Id = 1, Nom = "Pierre", Prenom = "Jean", Adresse = "1 rue des écoles", Ville = "Annecy" });
            context.Clients.Add(new Client { Id = 2, Nom = "Michel", Prenom = "Jean", Adresse = "2 rue des écoles", Ville = "Paris" });
            context.Clients.Add(new Client { Id = 3, Nom = "Roule", Prenom = "Jean", Adresse = "3 rue des écoles", Ville = "Lyon" });
            context.Clients.Add(new Client { Id = 4, Nom = "Paul", Prenom = "Jean", Adresse = "4 rue des écoles", Ville = "Marseille" });

            base.Seed(context);
        }
    }
}