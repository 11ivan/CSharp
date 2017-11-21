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
        public ActionResult Index()
        {
            ListaPersonasBL lista = new ListaPersonasBL();

            return View(lista.getListaPersonas());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();

            return View(gestoraPersonasBL.getPersona(id));
        }


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
                gestoraPersonasBL.updatePersona(persona);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            return View(gestoraPersonasBL.getPersona(id));

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            try
            {
                gestoraPersonasBL.deletePersona(id);
            }
            catch (Exception e)
            {
                return View("PgError");
            }
            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {           
            return View();
        }

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
                    gestoraPersonasBL.insertPersona(persona);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View("PgError");
                }
            }

           // return View();
        }

    }
}