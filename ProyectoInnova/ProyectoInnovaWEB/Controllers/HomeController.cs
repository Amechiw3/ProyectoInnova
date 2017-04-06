using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoInnovaWEB.Models;
using ProyectoInnovaWEB.Models.Manager;

namespace ProyectoInnovaWEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string fecha = "", string nbCand = "", string nbCiu = "")
        {
            ViewBag.Datos = CandidataManager.ListarContenidoBuscar(fecha, nbCand, nbCiu);
            ViewBag.Fechas = CandidataManager.getAniosConvocatoria();
            ViewBag.Municipio = CandidataManager.ListarContenidoMunicipios();
            return View();
        }

        public PartialViewResult Votar(int ID)
        {
            ViewBag.Datos = CandidataManager.getData(ID);
            return PartialView();
        }

        public ActionResult Votacion(int pkCandidata)
        {
            RankingManager.votar(pkCandidata);
            return RedirectToAction("Index");
        }
    }
}