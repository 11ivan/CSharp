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
        public ActionResult Index(int idCurso=-1)
        {
            VMListadoCursosConListadoAlumnosPorCurso listadoCursosConListadoAlumnosPorCurso = new VMListadoCursosConListadoAlumnosPorCurso();

            try
            {
                listadoCursosConListadoAlumnosPorCurso.cargaListadoCursos();
                if (idCurso!=-1)
                {
                    ViewBag.Mensaje = "La beca se asignó correctamente";
                    listadoCursosConListadoAlumnosPorCurso.cargaListadoAlumnosCurso(idCurso);
                }
            }
            catch(Exception e)
            {
                return View("ErrorPage");
            }

            return View(listadoCursosConListadoAlumnosPorCurso);
        }

        /// <summary>
        /// Accion Post de la vista Index, dado un id de Curso se encarga de cargar un listado de alumnos asociados al id de Curso dado
        /// </summary>
        /// <param name="ListadoCursos">Un entero que es el id del curso selecionado en la vista Index</param>
        /// <returns>Si hay errores retorna a la Vista ErrorPage sino retorna a la vista Index enviandole un ViewModel VMlistadoAlumnosPorCurso
        /// con la lista de alumnos por curso cargada</returns>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(int ListadoCursos)
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
        /// Dado un id de Alumno realiza una consulta a la base de datos y envia el Alumno asociado al id 
        /// hacia la Vista AsignaBeca
        /// </summary>
        /// <param name="ID">Un entero que es el id de un alumno</param>
        /// <returns>Si hay errores retorna a la Vista ErrorPage sino retorna a la vista AsignaBeca enviandole un ViewModel VMAlumnoConNombreCurso</returns>
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
        ///     Accion Post de la Vista AsignaBeca, dado un ViewModel VMAlumnoConNombreCurso comprueba que el modelo sea 
        ///     valido y asigna la beca al Alumno correspondiente de la tabla Alumnos con el mismo id que el ViewModel que nos llega.
        /// </summary>
        /// <param name="vmAlumnoConNombreCurso">
        ///     Un ViewModel VMAlumnoConNombreCurso que servirá para validar
        ///     el modelo y tambien obtener su id y beca para la asignacion de la misma.
        /// </param>
        /// <returns>
        ///     Si se captura alguna Excepcion retorna a la Vista ErrorPage, sino si el modelo no es valido
        ///     retorna a la vista AsignaBeca enviandole el ViewModel VMAlumnoConNombreCurso que nos llega para
        ///     mostrar los errores correspondientes, sino redirecciona a la Accion Index.
        /// </returns>
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
                return RedirectToAction("/Index", new { idCurso = vmAlumnoConNombreCurso.IdCurso });//si no le pongo slash no redirecciona correctamente ya que se salta Home [localhost:4540/Index] cuando deberia ser [localhost:4540/Home/Index]             
            }
            else
            {
                //Sino devolvemos a la vista AsignaBeca para mostrar los errores
                return View(vmAlumnoConNombreCurso);
            }                
        }



    }
}