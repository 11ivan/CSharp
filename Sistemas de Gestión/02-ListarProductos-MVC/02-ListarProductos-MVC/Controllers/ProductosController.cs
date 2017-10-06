using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_ListarProductos_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Listado()
        {
            return View();
        }
    }
}