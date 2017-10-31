using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _08_SG_LeerDeQuery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Boolean esMiPrimeraVez=true)
        {      
            string saludo = "Es la primera vez que entras";

            if (!esMiPrimeraVez)
            {
                saludo = "No es la primera vez que entras";
            }
            ViewData["Saludo"] = saludo;

            return View();
        }

     

    }
}





/*
    Debéis realizar una página en la que se lea del Query una variable que se llama “esMiPrimeraVez”.
    La vista debe mostrar un enlace hacia ella misma en la que le añadiremos en el query “….?esMiPrimeraVez=true”. 
    Además del enlace, la página debe mostrar el mensaje: “Es la primera vez que entras” o “No es la primera vez que entras”,
    dependiendo de si leemos del query la variable.
*/
