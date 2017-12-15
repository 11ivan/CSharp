using Capa_DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoPersonasBL
    {

        /// <summary>
        /// Ofrece un listado con las personas que hay en la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <returns>List<Persona></returns>
        public List<Persona> getListadoPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>();
            ListadoPersonasDAL listadoPersonasDAL = new ListadoPersonasDAL();
            try
            {
                listadoPersonas = listadoPersonasDAL.getListadoPersonas();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoPersonas;
        }

    }
}
