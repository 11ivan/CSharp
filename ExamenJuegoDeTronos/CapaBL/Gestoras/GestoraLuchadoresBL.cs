using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraLuchadoresBL
    {
        /// <summary>
        /// Devuelve un listado con los luchadores de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Luchador> getListaLuchadores()
        {
            List<Luchador> listadoLuchadores = new List<Luchador>();
            GestoraLuchadoresDAL gestoraLuchadoresDAL = new GestoraLuchadoresDAL();

            try
            {
                listadoLuchadores = gestoraLuchadoresDAL.getListaLuchadores();
            }
            catch (Exception e)
            {
                throw e;
            }            
            return listadoLuchadores;
        }




    }
}
