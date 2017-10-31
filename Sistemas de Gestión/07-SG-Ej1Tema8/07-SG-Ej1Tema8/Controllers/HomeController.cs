using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07_SG_Ej1Tema8.Models.Entities;
using _07_SG_Ej1Tema8.Models.ViewModel;
using _07_SG_Ej1Tema8.Models.Lists;
using System.Web.UI.WebControls;

namespace _07_SG_Ej1Tema8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {         
            ModelForView modelForView = new ModelForView();
            return View(modelForView);
        }


        /// <summary>
        /// Receive the Object ModelForView,  fill the object ModelForView2 with necessary parametters and return this
        /// </summary>
        /// <param name = "model"> Type ModelForView</param>
        /// <returns>Type = View</returns>
        [HttpPost]
        public ActionResult ModifyPerson(ModelForView model)
        {
            ModelForView2 modelForView2 = new ModelForView2();
            modelForView2.Nombre = model.Nombre;
            modelForView2.Apellido = model.Apellido;
            modelForView2.Departamen.Nombre = model.ListDepartamentos.getDepartamento(model.IdDepartamento).Nombre;

            return View(modelForView2);
        }


    }
}