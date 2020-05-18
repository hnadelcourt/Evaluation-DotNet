using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluation.Models;
using System.Data.Entity;
using Evaluation.ViewModels;
using System.Threading.Tasks;


namespace Evaluation.Controllers
{
    public class AccueilController : Controller
    {
        private IDal dal;

        public AccueilController() : this(new Dal())
        {
        }

        public AccueilController(IDal dalIoc)
        {
            dal = dalIoc;
        }
            public ActionResult Index()
        {
            
            List<Client> listeDesClients = dal.ObtientTousLesClients();
            return View(listeDesClients);
            
        }

        public ActionResult CreerClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerClient(Client client)
        {
            if (dal.ClientExiste(client.Nom,client.Prenom))
            {
                ModelState.AddModelError("Nom", "Ce nom de client existe déjà");
                return View(client);
            }
            if (!ModelState.IsValid)
                return View(client);
            dal.CreerClient(client.Nom, client.Prenom, client.Adresse, client.Ville);
            return RedirectToAction("Index");
        }

        
        public ActionResult ModifierClient(int? id)
        {
            if (id.HasValue)
            {
                Client client = dal.ObtientTousLesClients().FirstOrDefault(r => r.Id == id.Value);
                if (client == null)
                    return View("Error");
                return View(client);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult ModifierClient(Client client)
        {
            if (!ModelState.IsValid)
                return View(client);
            dal.ModifierClient(client.Id, client.Nom, client.Prenom, client.Adresse, client.Ville);
            return RedirectToAction("Index");
        }

        public ActionResult SupprimerClient(int? id)
        {
            if (id.HasValue)
            {
                Client client = dal.ObtientTousLesClients().FirstOrDefault(r => r.Id == id.Value);
                if (client == null)
                    return View("Error");
                return View(client);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult SupprimerClient(Client client)
        {
            if (!ModelState.IsValid)
                return View(client);
            dal.SupprimerClient(client.Id, client.Nom, client.Prenom, client.Adresse, client.Ville);
            return RedirectToAction("Index");
        }

        public ActionResult Recherche(RechercheViewModel rechercheViewModel)
        {
            if (!string.IsNullOrWhiteSpace(rechercheViewModel.Recherche))
                rechercheViewModel.listeDesClients = dal.ObtientTousLesClients().Where(r => r.Ville.IndexOf(rechercheViewModel.Recherche, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
            else
                rechercheViewModel.listeDesClients = new List<Client>();
            return View(rechercheViewModel);
        }



    }
}