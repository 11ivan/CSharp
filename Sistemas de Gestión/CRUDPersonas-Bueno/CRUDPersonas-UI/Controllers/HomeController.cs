using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDPersonas_BL.Listados;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Gestoras;

namespace CRUDPersonas_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// Envía un listado de personas a la vista Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ListaPersonasBL lista = new ListaPersonasBL();
            List<Persona> listaPersonas = new List<Persona>();
            try
            {
                listaPersonas = lista.getListaPersonas();
            }
            catch (Exception e)
            {
                throw e;
            }
            //ViewData["affectedRows"]="filas afectadas";
            return View(listaPersonas);
        }

        /// <summary>
        /// Recibe el id de una persona de la vista Index y envía la persona asociada a ese id en la base de datos
        /// a la vista Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            Persona persona = new Persona();
            try
            {
                persona = gestoraPersonasBL.getPersona(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(persona);
        }

        /// <summary>
        /// Recibe una pesona desde la vista Edit, si los datos no correctos
        /// devuelve la misma persona a la vista Edit sino actualiza la persona en la base de datos
        /// y redirecciona a la vista Index
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }
            else
            {
                //Actualizar Persona y Redireccionar a Index
                GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
                try
                {
                    ViewData["affectedRows"] =gestoraPersonasBL.updatePersona(persona)+" filas afectadas";
                }
                catch (Exception e)
                {
                    throw e;
                }
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// REcibe el id de una persona desde la vista Index, consulta a la base de datos y envía 
        /// la persona asociada a ese id a la vista Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            Persona persona = new Persona();
            try
            {
                persona = gestoraPersonasBL.getPersona(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(persona);
        }

        /// <summary>
        /// Recibe el id de una persona desde la vista Delete y elimina la persona asociada
        /// a ese id en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            String filasAfectadas = "";
            try
            {
                //ViewData["affectedRows"] = gestoraPersonasBL.deletePersona(id)+" filas afectadas";
                filasAfectadas = gestoraPersonasBL.deletePersona(id) + " filas afectadas";
            }
            catch (Exception e)
            {
                return View("PgError");
            }
            return RedirectToAction("Index");
            //return View("Index");

        }

        /// <summary>
        /// Enlaza con la vista Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {           
            return View();
        }

        /// <summary>
        /// Recibe una persona desde la vista Create, comprueba que sus datos sean correctos, 
        /// si no lo son devuelve la persona a la vista Create sino inserta la nueva persona
        /// en la base de datos y redireccion a la vista Index
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();

            if (!ModelState.IsValid)
            {
                return View(persona);
            }
            else
            {
                try
                {
                    ViewData["affectedRows"] = gestoraPersonasBL.insertPersona(persona)+" filas afectadas";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View("PgError");
                }
            }
        }

        /// <summary>
        /// Recibe el id de una persona, realiza la consulta a la base de datos con ese id
        /// y envía la persona asociada a la vista Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            Persona persona = new Persona();
            try
            {
                persona = gestoraPersonasBL.getPersona(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(persona);
        }

        /*[HttpPost]
        //[ActionName("Details")]
        public ActionResult Details()
        {
            return RedirectToAction("Index");
        }*/


    }
}