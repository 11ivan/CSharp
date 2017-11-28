using Capa_DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoAlumnosBL
    {

        /// <summary>
        /// Ofrece un listado con los alumnos de la base de datos
        /// </summary>
        /// <returns>List<Alumno></returns>
        public List<Alumno> getListadoAlumnos()
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            ListadoAlumnosDAL listadoAlumnosDAL = new ListadoAlumnosDAL();
            try
            {
                listadoAlumnos = listadoAlumnosDAL.getListadoAlumnos();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoAlumnos;
        }

        /// <summary>
        /// Dado el nombre de un curso, ofrece un listado con los alumnos asociados a ese curso de la base de datos
        /// </summary>
        /// <returns>List<Alumno></returns>
        public List<Alumno> getListadoAlumnosCurso(string nombreCurso)
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            ListadoAlumnosDAL listadoAlumnosDAL = new ListadoAlumnosDAL();
            try
            {
                listadoAlumnos = listadoAlumnosDAL.getListadoAlumnosCurso(nombreCurso);
            }
            catch (Exception e)
            {
                throw e;
            }
            return listadoAlumnos;
        }


    }
}
