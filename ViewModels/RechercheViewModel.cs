using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Evaluation.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace Evaluation.ViewModels
{
    public class RechercheViewModel
    {
        public string Recherche { get; set; }
        public List<Client> listeDesClients { get; set; }
    }
}