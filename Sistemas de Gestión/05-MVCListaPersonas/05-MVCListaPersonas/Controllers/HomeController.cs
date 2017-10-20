using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _05_MVCListaPersonas.Models;

/*
Realizar un ejercicio en el que un controlador le envía a una vista un listado con varios objetos de clsPersona.
El listado lo realizaréis usando List<clsPersona>.
Pondremos un enlace desde Index para ir a esta vista.
 */

namespace _05_MVCListaPersonas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            GestoraHomeController gestoraHome = new GestoraHomeController();
            //ListPersonas listaPersonas = gestoraHome.cargaListaPersonas();
            ListPersonas listaPersonas = new ListPersonas();
            gestoraHome.cargaListaPersonas(listaPersonas);

            return View(listaPersonas);
        }
    }
}