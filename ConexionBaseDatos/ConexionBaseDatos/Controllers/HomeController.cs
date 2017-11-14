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
            Conexion conexion = new Conexion();
            return View(conexion.getPersonas());
        }


        //[HttpPost]
        /*public ActionResult Index2()
        {
            //String cadena = "";
            Conexion conexion = new Conexion();
            conexion.openConnection();

            switch (conexion.getState())
            {
                case "Closed":
                        ViewData["estado"] = "Conexion cerrada";
                    break;

                case "Open":
                        ViewData["estado"] = "Conexion establecida";                 
                    break;
            }
            return View("Index");
        }*/



    }
}