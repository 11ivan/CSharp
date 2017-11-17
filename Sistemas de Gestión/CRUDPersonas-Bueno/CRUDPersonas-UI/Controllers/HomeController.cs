using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDPersonas_BL.Listados;

namespace CRUDPersonas_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ListaPersonasBL lista = new ListaPersonasBL();

            return View(lista.getListaPersonas());
        }
    }
}