using Capa_DAL.Connection;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraPersonajeConTransformacionesYHabilidadesDAL
    {
        public async Task<List<PersonajeConTransformacionesYHabilidades>> getListaPersonajeConTransformacionesYHabilidades()
        {
            Conexion conexion = new Conexion();
            List<PersonajeConTransformacionesYHabilidades> listadoPersonajeConTransformacionesYHabilidades = new List<PersonajeConTransformacionesYHabilidades>();
            HttpClient httpClient = new HttpClient();

            try
            {
                string body = await httpClient.GetStringAsync(conexion.Server);
                httpClient.Dispose();
                listadoPersonajeConTransformacionesYHabilidades = JsonConvert.DeserializeObject<List<PersonajeConTransformacionesYHabilidades>>(body);
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoPersonajeConTransformacionesYHabilidades;
        }
    }
}
