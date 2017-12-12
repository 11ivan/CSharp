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
        /// Dado un id de Alumno realiza una consulta a la tabla Alumnos de la base de datos y devuelve el alumno asociado al id
        /// </summary>
        /// <param name="idAlumno">Un entero que es el id del Alumno</param>
        /// <returns>Devuelve un Alumno</returns>
        public Alumno getAlumno(int idAlumno)
        {
            Alumno alumno = new Alumno();
            GestoraAlumnosDAL gestoraAlumnosDAL = new GestoraAlumnosDAL();

            try
            {
                alumno = gestoraAlumnosDAL.getAlumno(idAlumno);
            }
            catch (Exception e)
            {
                throw e;
            }

            return alumno;
        }

        /// <summary>
        /// Dado un id de alumno y un importe de beca actualiza la beca del alumno asociado al id con la cantidad dada
        /// </summary>
        /// <param name="idAlumno">Un entero que es el id del alumno</param>
        /// <param name="importeBeca">Un decimal que es el importe de la beca ha asignar</param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int asignaBeca(int idAlumno, decimal importeBeca)
        {          
            int affectedRows = 0;
            GestoraAlumnosDAL gestoraAlumnosDAL = new GestoraAlumnosDAL();

            try
            {
                affectedRows = gestoraAlumnosDAL.asignaBeca(idAlumno, importeBeca);
            }
            catch (Exception e)
            {
                throw e;
            }

            return affectedRows;
        }

    }
}
