using Capa_DAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraTransformacionesBL
    {

        public List<Transformacion> getListaTransformaciones()
        {
            List<Transformacion> listadoTransformaciones = new List<Transformacion>();
            GestoraTransformacionesDAL gestoraTransformacionesDAL = new GestoraTransformacionesDAL();

            try
            {
                listadoTransformaciones = gestoraTransformacionesDAL.getListaTransformaciones();
            }
            catch (Exception e)
            {
                throw e;
            }           
            return listadoTransformaciones;
        }


        public Transformacion getTransformacion(int id)
        {
            Transformacion transformacion = new Transformacion();
            GestoraTransformacionesDAL gestoraTransformacionesDAL = new GestoraTransformacionesDAL();
            try
            {
                transformacion = gestoraTransformacionesDAL.getTransformacion(id);
            }
            catch (Exception e)
            {
                throw e;
            }           
            return transformacion;
        }

    }
}
