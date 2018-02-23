using Capa_BL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIDragonBall.Controllers
{
    public class PersonajesController : ApiController
    {
        // GET api/Personajes
        public IEnumerable<Personaje> Get()
        {
            List<Personaje> listadoPersonajes = new List<Personaje>();
            GestoraPersonajesBL gestoraPersonajesBL = new GestoraPersonajesBL();

            try
            {
                listadoPersonajes = gestoraPersonajesBL.getListaPersonajes();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoPersonajes;
        }

        // GET api/Personajes/5
        public Personaje Get(int id)
        {
            Personaje personaje = new Personaje();
            GestoraPersonajesBL gestoraPersonajesBL = new GestoraPersonajesBL();

            try
            {
                personaje= gestoraPersonajesBL.getPersonaje(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return personaje;
        }

        // POST api/Personajes
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Personajes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Personajes/5
        public void Delete(int id)
        {
        }
    }
}
