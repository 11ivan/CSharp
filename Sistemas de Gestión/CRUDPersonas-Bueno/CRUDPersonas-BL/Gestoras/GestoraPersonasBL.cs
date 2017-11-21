using CRUDPersonas_DAL.Gestoras;
using CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_BL.Gestoras
{
    public class GestoraPersonasBL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Persona getPersona(int id)
        {
            Persona persona = new Persona();
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            persona=gestoraPersonasDAL.getPersona(id);
            return persona;
        }

        public int updatePersona(Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            affectedRows = gestoraPersonasDAL.updatePersona(persona);

            return affectedRows;
        }

        public int deletePersona(int id)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();

            affectedRows= gestoraPersonasDAL.deletePersona(id);
            return affectedRows;
        }


        public int insertPersona(Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            affectedRows = gestoraPersonasDAL.insertPersona(persona);
            return affectedRows;        }

    }
}
