using Capa_DAL.Gestoras;
using Entidades;
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
        /// Recibe el id de un curso, hace una consulta a la base de datos con ese id y devuelve el curso asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Curso</returns>
        public Curso getCurso(int id)
        {
            Curso curso = new Curso();
            GestoraCursosDAL gestoraCursosDAL = new GestoraCursosDAL();
            try
            {
                curso = gestoraCursosDAL.getCurso(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return curso;
        }


    }
}
