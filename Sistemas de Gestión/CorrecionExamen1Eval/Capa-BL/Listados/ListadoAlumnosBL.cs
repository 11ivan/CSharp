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
        /// Ofrece un listado con los Alumnos de la tabla Alumnos de la base de datos
        /// </summary>
        /// <returns type="List<Alumno>">Devuelve un listado de alumnos</returns>
        public List<Alumno> getListadoAlumnos()
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            ListadoAlumnosDAL listadoAlumnosDAL = new ListadoAlumnosDAL();

            try
            {
                listadoAlumnos = listadoAlumnosDAL.getListadoAlumnos();
            }catch(Exception e)
            {
                throw e;
            }

            return listadoAlumnos;
        }

        /// <summary>
        /// Ofrece un listado con los alumnos de un curso concreto de la tabla Alumnos de la base de datos
        /// </summary>
        /// <param name="idCurso">Un entero que es el id del Curso</param>
        /// <returns type="List<Alumno>">Devuelve un listado con los alumnos de un curso concreto</returns>
        public List<Alumno> getListadoAlumnosCurso(int idCurso)
        {
            List<Alumno> listadoAlumnosCurso = new List<Alumno>();
            ListadoAlumnosDAL listadoAlumnosDAL = new ListadoAlumnosDAL();

            try
            {
                listadoAlumnosCurso = listadoAlumnosDAL.getListadoAlumnosCurso(idCurso);
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoAlumnosCurso;
        }

    }
}
