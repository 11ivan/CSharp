using Capa_DAL.Gestoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraPersonasBL
    {

        /// <summary>
        /// Dado un id de Persona realiza una consulta a la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la Persona</param>
        /// <returns>La persona devuelta será la persona asociada al id dado</returns>
        public Persona getPersona(int idPersona)
        {
            Persona persona = null;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            try
            {
                persona = gestoraPersonasDAL.getPersona(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }

            return persona;
        }

        /// <summary>
        /// Recibe una persona y la inserta en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int insertPersona(Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            try
            {
                affectedRows = gestoraPersonasDAL.insertPersona(persona);
            }
            catch (Exception e)
            {
                throw e;
            }
            return affectedRows;
        }

        /// <summary>
        /// Dado un id de Persona elimina la persona asociada en la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la persona</param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int deletePersona(int idPersona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();

            try
            {
                affectedRows = gestoraPersonasDAL.deletePersona(idPersona);             
            }
            catch (Exception e)
            {
                throw e;
            }

            return affectedRows;
        }

        /// <summary>
        /// Dado un id de Persona y un Objeto Persona, actualiza la Persona asociada al id dado en la tabla Personas 
        /// con los datos del objeto Persona que llega por parametros
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la Persona</param>
        /// <param name="persona">Un objeto Persona cuyas propiedades se usarán para actualizar la Persona de la tabla Personas</param>
        /// <returns>Un entero con la cantidad de filas afectadas</returns>
        public int updatePersona(int idPersona, Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            try
            {
                affectedRows = gestoraPersonasDAL.updatePersona(idPersona, persona);
            }
            catch (Exception e)
            {
                throw e;
            }
            return affectedRows;
        }


    }
}
