using ConexionBaseDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConexionBaseDatos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        
        public ActionResult Index2()
        {
            //String cadena = "";
            Conexion conexion = new Conexion();
            conexion.openConnection();

            switch (conexion.connection.State.ToString())
            {
                case "Closed":
                    ViewData["estado"] = "Conexion cerrada";
                    break;

                case "Open":
                    ViewData["estado"] = "Conexion establecida";
                    break;
            }
            return View("Index");
        }



    }
}