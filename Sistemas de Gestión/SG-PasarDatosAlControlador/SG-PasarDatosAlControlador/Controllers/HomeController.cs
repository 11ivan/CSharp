using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_PasarDatosAlControlador.Models;

namespace SG_PasarDatosAlControlador.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Editar()
        {
            Persona p1 = new Persona();
            p1.Nombre = "Ivan";
            p1.Apellido = "Castillo";
            return View(p1);
        }

        [HttpPost]
        public ActionResult ModifyPerson(Persona persona)
        {
            //persona.Nombre = "No VEAS";
            //persona.Apellido = "Mother Fucker";
            return View(persona);
        }





    }
}