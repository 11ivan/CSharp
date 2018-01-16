using Capa_BL.Gestoras;
using Capa_BL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIPersonasDB.Controllers
{
    public class PersonasController : ApiController
    {
        // GET api/Personas
        public IEnumerable<Persona> Get()
        {
            ListadoPersonasBL listadoPersonasBL = new ListadoPersonasBL();
            ObservableCollection<Persona> observableCollection = new ObservableCollection<Persona>(listadoPersonasBL.getListadoPersonas());
            return observableCollection;
        }

        // GET api/Personas/5
        public Persona Get(int id)
        {
            Persona persona = new Persona();
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();

            persona = gestoraPersonasBL.getPersona(id);

            return persona;
        }

        // POST api/Personas
        public void Post([FromBody]Persona value)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.insertPersona(value);
        }

        // PUT api/Personas/5
        public void Put(int id, [FromBody]Persona value)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.updatePersona(id, value);
        }

        // DELETE api/Personas/5
        public void Delete(int id)
        {
            
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.deletePersona(id);
        }
    }
}
