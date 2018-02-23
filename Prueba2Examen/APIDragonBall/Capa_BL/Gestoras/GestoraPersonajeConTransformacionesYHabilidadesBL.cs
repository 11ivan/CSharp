using Capa_DAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraPersonajeConTransformacionesYHabilidadesBL
    {
        public List<PersonajeConTransformacionesYHabilidades> getListaPersonajeConTransformacionesYHabilidades()
        {
            List<PersonajeConTransformacionesYHabilidades> listadoPersonajeConTransformacionesYHabilidades = new List<PersonajeConTransformacionesYHabilidades>();
            GestoraPersonajeConTransformacionesYHabilidadesDAL gestoraPersonajeConTransformacionesYHabilidadesDAL = new GestoraPersonajeConTransformacionesYHabilidadesDAL();

            try
            {
                listadoPersonajeConTransformacionesYHabilidades = gestoraPersonajeConTransformacionesYHabilidadesDAL.getListaPersonajeConTransformacionesYHabilidades();            
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoPersonajeConTransformacionesYHabilidades;
        }

    }
}
