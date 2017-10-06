using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HelloWorld_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public String Index()
        {
            return ("Hola Mundo desde el controlador");
        }

        public ActionResult Saludo()
        {
            return View();
        }
    }
}