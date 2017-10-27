using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07_SG_Ej1Tema8.Models.Entities;
using _07_SG_Ej1Tema8.Models.ViewModel;

namespace _07_SG_Ej1Tema8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Departamento dep1 = new Departamento("Informática", 1);
            Departamento dep2 = new Departamento("Ciencias", 2);
            Departamento dep3 = new Departamento("Investigación", 3);
            Departamento dep4 = new Departamento("Física", 4);
            ModelForView modelForView = new ModelForView();
            modelForView.Nombre = "Ivan";
            modelForView.Apellido = "Castillo";
            modelForView.ListDepartamentos.addDepartamento(dep1);
            modelForView.ListDepartamentos.addDepartamento(dep2);
            modelForView.ListDepartamentos.addDepartamento(dep3);
            modelForView.ListDepartamentos.addDepartamento(dep4);
            return View(modelForView);
        }


        [HttpPost]
        public ActionResult modifyPerson(ModelForView model)
        {
            ModelForView2 modelForView2 = new ModelForView2();
            modelForView2.Nombre = model.Nombre;
            modelForView2.Apellido = model.Apellido;
            modelForView2.getsetdepartamento.Nombre = model.ListDepartamentos.getDepartamento(model.IdDepartamento).Nombre;

            return View(modelForView2);
        }


    }
}