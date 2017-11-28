using Capa_DAL.Gestoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraAlumnosBL
    {

        /// <summary>
        /// Recibe el id de un alumno, hace una consulta a la base de datos con ese id y devuelve el alumno asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alumno</returns>
        public Alumno getAlumno(int id)
        {
            Alumno alumno = new Alumno();
            GestoraAlumnosDAL gestoraAlumnosDAL = new GestoraAlumnosDAL();
            try
            {
                alumno = gestoraAlumnosDAL.getAlumno(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return alumno;
        }


    }
}
