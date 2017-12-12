using Capa_DAL.Gestoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraCursosBL
    {

        /// <summary>
        /// Dado un id de curso realiza una consulta a la base de datos y devuelve el nombre del curso asociado al id
        /// </summary>
        /// <param name="idCurso">Un entero que es el id del curso</param>
        /// <returns>Devuelve una cadena que es el nombre del curso</returns>
        public string getNombreCurso(int idCurso)
        {
            string nombreCurso = "";
            GestoraCursosDAL gestoraCursosDAL = new GestoraCursosDAL();

            try
            {
                nombreCurso = gestoraCursosDAL.getNombreCurso(idCurso);
            }
            catch (Exception e)
            {
                throw e;
            }

            return nombreCurso;
        }

    }
}
