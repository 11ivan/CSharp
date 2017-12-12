using Capa_BL.Gestoras;
using CorrecionExamen1Eval_UI.Models.ViewModels;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorrecionExamen1Eval_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            VMListadoCursosConListadoAlumnosPorCurso listadoCursosConListadoAlumnosPorCurso = new VMListadoCursosConListadoAlumnosPorCurso();

            try
            {
                listadoCursosConListadoAlumnosPorCurso.cargaListadoCursos();
            }
            catch(Exception e)
            {
                return View("ErrorPage");
            }

            return View(listadoCursosConListadoAlumnosPorCurso);
        }

        /// <summary>
        /// Esta accion se encarga de 
        /// </summary>
        /// <param name="IdCursoSeleccionado">Un entero que es el id del curso selecionado en la vista Index</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int ListadoCursos)
        {
            VMListadoCursosConListadoAlumnosPorCurso listadoCursosConListadoAlumnosPorCurso = new VMListadoCursosConListadoAlumnosPorCurso();

            try
            {
                listadoCursosConListadoAlumnosPorCurso.cargaListadoCursos();
                listadoCursosConListadoAlumnosPorCurso.cargaListadoAlumnosCurso(ListadoCursos);
            }
            catch (Exception e)
            {
                return View("ErrorPage");
            }
            return View("Index", listadoCursosConListadoAlumnosPorCurso);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult AsignaBeca(int ID)
        {
            VMAlumnoConNombreCurso vmAlumnoConNombreCurso = new VMAlumnoConNombreCurso();
            GestoraAlumnosBL gestoraAlumnosBL = new GestoraAlumnosBL();
            Alumno alumno = new Alumno();
            GestoraCursosBL gestoraCursosBL = new GestoraCursosBL();

            try
            {
                alumno = gestoraAlumnosBL.getAlumno(ID);

                vmAlumnoConNombreCurso.ID = alumno.ID;
                vmAlumnoConNombreCurso.Nombre = alumno.Nombre;
                vmAlumnoConNombreCurso.Apellidos = alumno.Apellidos;
                vmAlumnoConNombreCurso.IdCurso = alumno.IdCurso;
                vmAlumnoConNombreCurso.Beca = alumno.Beca;

                vmAlumnoConNombreCurso.NombreCurso = gestoraCursosBL.getNombreCurso(alumno.IdCurso);
            }
            catch (Exception e)
            {
                return View("ErrorPage");
            }
            return View(vmAlumnoConNombreCurso);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vmAlumnoConNombreCurso"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AsignaBeca(VMAlumnoConNombreCurso vmAlumnoConNombreCurso)
        {
            if (ModelState.IsValid)
            {
                //Asignamos la beca y volvemos a la vista index
                GestoraAlumnosBL gestoraAlumnosBL = new GestoraAlumnosBL();
                try
                {
                    gestoraAlumnosBL.asignaBeca(vmAlumnoConNombreCurso.ID, vmAlumnoConNombreCurso.Beca);
                }
                catch (Exception e)
                {
                    return View("ErrorPage");
                }
                return RedirectToAction("Index");
            }
            else
            {
                //Sino devolvemos a la vista AsignaBeca para mostrar los errores
                return View(vmAlumnoConNombreCurso);
            }

            
            
        }

    }
}