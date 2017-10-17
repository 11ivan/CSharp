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
            ListPersonas listaPersonas = new ListPersonas();
            Persona p1 = new Persona();
            Persona p2 = new Persona();
            Persona p3 = new Persona();

            p1.setID(1);
            p1.setNombre("Paco");
            p1.setApellidos("Calavera Caravela");
            p1.setFechaNac(new DateTime(1985, 5, 20));
            p1.setDireccion("Abajol puente");
            p1.setTelefono("654789321");

            p2.setID(2);
            p2.setNombre("Manué");
            p2.setApellidos("Gonzalez Blanco");
            p2.setFechaNac(new DateTime(1989, 11, 27));
            p2.setDireccion("C/ Cortada al laol limonero");
            p2.setTelefono("621987519");

            p3.setID(3);
            p3.setNombre("Manolo");
            p3.setApellidos("Eldel Bombo");
            p3.setFechaNac(new DateTime(1950, 3, 5));
            p3.setDireccion("Donde se puea tocal bombo");
            p3.setTelefono("698156487");

            listaPersonas.addPersona(p1);
            listaPersonas.addPersona(p2);
            listaPersonas.addPersona(p3);

            return View(listaPersonas);
        }
    }
}