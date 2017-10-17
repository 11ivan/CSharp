using _04_PasarDatosView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_PasarDatosView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Persona persona = new Persona();

            ViewData["Saludo"] = saludo();
            ViewBag.Fecha = DateTime.Now;
            persona.setNombre("Ivan");
            return View(persona);
        }

        public String saludo() {
            String Saludo=" ";

            switch (DateTime.Now.Hour)
            {
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    Saludo = "Buenos días";
                    break;

                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    Saludo = "Buenas tardes";
                    break;

                case 21:
                case 22:
                case 23:
                case 00:
                case 01:
                case 02:
                case 03:
                case 04:
                case 05:
                case 06:
                case 07:
                    Saludo = "Buenas noches";
                    break;
            }

            return Saludo;
        }
    }
}