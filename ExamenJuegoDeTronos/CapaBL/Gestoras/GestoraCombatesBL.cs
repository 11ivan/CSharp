using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraCombatesBL
    {
        /// <summary>
        /// Devuelve un listado con los copmbates de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Combate> getListaCombates()
        {
            List<Combate> listadoCombates = new List<Combate>();
            GestoraCombatesDAL gestoraCombatesDAL = new GestoraCombatesDAL();

            try
            {
                listadoCombates = gestoraCombatesDAL.getListaCombates();
            }
            catch (Exception e)
            {
                throw e;
            }           
            return listadoCombates;
        }



    }
}
