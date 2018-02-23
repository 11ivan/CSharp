using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraClasificacionCombateBL
    {
        /// <summary>
        /// Inserta una clasificacion de comabate en la base de datos
        /// </summary>
        /// <param name="clasificacionCombate"></param>
        /// <returns></returns>
        public int insertClasificacionCombate(ClasificacionCombate clasificacionCombate)
        {
            int affectedRows = 0;
            GestoraClasificacionCombateDAL gestoraClasificacionCombateDAL = new GestoraClasificacionCombateDAL();

            try
            {
                affectedRows = gestoraClasificacionCombateDAL.insertClasificacionCombate(clasificacionCombate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedRows;
        }
    }
}
