using Capa_DAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraHabilidadesBL
    {

        public List<Habilidad> getListaTransformaciones()
        {
            List<Habilidad> listadoHabilidades = new List<Habilidad>();
            GestoraHabilidadesDAL gestoraHabilidadesDAL = new GestoraHabilidadesDAL();

            try
            {
                listadoHabilidades = gestoraHabilidadesDAL.getListaHabilidades();
            }
            catch (Exception e)
            {
                throw e;
            }            
            return listadoHabilidades;
        }


        public Habilidad getHabilidad(int id)
        {
            Habilidad habilidad = new Habilidad();
            GestoraHabilidadesDAL gestoraHabilidadesDAL = new GestoraHabilidadesDAL();
            try
            {
                habilidad = gestoraHabilidadesDAL.getHabilidad(id);
            }
            catch (Exception e)
            {
                throw e;
            }           
            return habilidad;
        }
    }
}
