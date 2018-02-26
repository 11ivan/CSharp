using Capa_DAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraPersonajesBL
    {
        public List<Personaje> getListaPersonajes()
        {
            List<Personaje> listadoPersonajes = new List<Personaje>();
            GestoraPersonajesDAL gestoraPersonajesDAL = new GestoraPersonajesDAL();
            try
            {
                listadoPersonajes = gestoraPersonajesDAL.getListaPersonajes();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoPersonajes;
        }

        public Personaje getPersonaje(int id)
        {
            Personaje personaje = new Personaje();
            GestoraPersonajesDAL gestoraPersonajesDAL = new GestoraPersonajesDAL();        
            try
            {
                personaje = gestoraPersonajesDAL.getPersonaje(id);
            }
            catch (Exception e)
            {
                throw e;
            }           
            return personaje;
        }



    }
}
