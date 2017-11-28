using Capa_BL.Listados;
using Ejercicio1Examen.Models;
using Ejercicio1Examen.Models.ViewModels;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio1Examen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //List<Curso> listado = new List<Curso>();
            //ListadoCursosBL listadoCursosBL = new ListadoCursosBL();
            VMListadoCursos vMListadoCursos = new VMListadoCursos();
            try
            {
                vMListadoCursos.cargaListadoCursos();
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(vMListadoCursos);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            ListadoVMAlumnoConNombreCurso listadoVMAlumnoConNombreCurso = new ListadoVMAlumnoConNombreCurso();

            try
            {
                listadoVMAlumnoConNombreCurso.cargaListadoAlumnosConNombreCurso(id);
                List<VMAlumnoConNombreCurso> lista = new List<VMAlumnoConNombreCurso>();
            }
            catch (Exception e)
            {
                throw e;
            }
            return View("Details", listadoVMAlumnoConNombreCurso);
        }

        
        public ActionResult Details(ListadoVMAlumnoConNombreCurso listadoVMAlumnoConNombreCurso)
        {
            //comprobar modelo válido
            return View(listadoVMAlumnoConNombreCurso);

        }

    }
}