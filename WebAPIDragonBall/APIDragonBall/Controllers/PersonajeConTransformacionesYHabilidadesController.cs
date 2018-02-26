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
    public class PersonajeConTransformacionesYHabilidadesController : ApiController
    {
        // GET: api/PersonajeConTransformacionesYHabilidades
        public IEnumerable<PersonajeConTransformacionesYHabilidades> Get()
        {
            List<PersonajeConTransformacionesYHabilidades> listadoPersonajesConTransformacionesYHabilidades = new List<PersonajeConTransformacionesYHabilidades>();
            GestoraPersonajeConTransformacionesYHabilidadesBL gestoraPersonajeConTransformacionesYHabilidadesBL = new GestoraPersonajeConTransformacionesYHabilidadesBL();
            try
            {
                listadoPersonajesConTransformacionesYHabilidades = gestoraPersonajeConTransformacionesYHabilidadesBL.getListaPersonajeConTransformacionesYHabilidades();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoPersonajesConTransformacionesYHabilidades;
        }

        // GET: api/PersonajeConTransformacionesYHabilidades/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PersonajeConTransformacionesYHabilidades
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PersonajeConTransformacionesYHabilidades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PersonajeConTransformacionesYHabilidades/5
        public void Delete(int id)
        {
        }
    }
}
