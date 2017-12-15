using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using Capa_BL.Listados;
using System.Collections.ObjectModel;
using Capa_BL.Gestoras;

namespace Capa_UI.Controllers
{
    [Route("api/[controller]")]
    public class PersonasController : Controller

    {
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            var query = Request.QueryString;
            string queryString=query.ToString().Substring("=", );
            ListadoPersonasBL listadoPersonasBL = new ListadoPersonasBL();
            ObservableCollection<Persona> observableCollection = new ObservableCollection<Persona>(listadoPersonasBL.getListadoPersonas());
            return observableCollection;
        }

        // GET api/Personas/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            Persona persona = new Persona();
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();

            persona = gestoraPersonasBL.getPersona(id);

            return persona;
        }

        // POST api/Personas
        [HttpPost]
        public void Post([FromBody]Persona value)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.insertPersona(value);
        }

        // PUT api/Personas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Persona value)
        {
            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.updatePersona(id, value);
        }

        // DELETE api/Personas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();
            gestoraPersonasBL.deletePersona(id);
        }

    }
}
