using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraCasasBL
    {
        /// <summary>
        /// Devuelve un listado con las casas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Casa> getListaCasas()
        {
            List<Casa> listadoCasas = new List<Casa>();
            GestoraCasasDAL gestoraCasasDAL = new GestoraCasasDAL();

            try
            {
                listadoCasas = gestoraCasasDAL.getListaCasas();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return listadoCasas;
        }

        /// <summary>
        /// Dado un id devuelve la casa asociada al mismo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Casa getCasa(int id)
        {
            Casa casa = new Casa();
            GestoraCasasDAL gestoraCasasDAL = new GestoraCasasDAL();

            try
            {
                casa = gestoraCasasDAL.getCasa(id);
            }
            catch (Exception e)
            {
                throw e;
            }          
            return casa;
        }


    }
}
