using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Evaluation.Models
{
    public interface IDal :IDisposable
    {
        void CreerClient(string nom, string prenom, string adresse, string ville);
        void ModifierClient(int id, string nom, string prenom, string adresse, string ville);

        void SupprimerClient(int id, string nom, string prenom, string adresse, string ville);

        bool ClientExiste(string nom, string prenom);

        
        List<Client> ObtientTousLesClients();

    }
}
