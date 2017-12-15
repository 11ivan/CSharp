using Capa_DAL.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Listados
{
    public class ListadoAlumnosDAL
    {

        /// <summary>
        /// Método que ofrece un listado con los Alumnos de la tabla Alumnos dela base de datos
        /// </summary>
        /// <returns>List<Alumno></returns>
        public List<Alumno> getListadoAlumnos()
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            Alumno alumno = null;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idAlumno, nombreAlumno, apellidosAlumno, idCurso, beca From Alumnos";
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        alumno = new Alumno();
                        alumno.ID = (int)dataReader["idAlumno"];
                        alumno.Nombre = (string)dataReader["nombreAlumno"];
                        alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                        alumno.IdCurso = (int)dataReader["idCurso"];
                        if (dataReader["beca"]!=System.DBNull.Value) {
                            alumno.Beca = (decimal)dataReader["beca"];
                        }
                        listadoAlumnos.Add(alumno);
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
            }catch(SqlException e)
            {
                throw e;
            }
            return listadoAlumnos;
        }

        /// <summary>
        /// Ofrece un listado con los alumnos de un curso concreto de la tabla Alumnos
        /// </summary>
        /// <param name="idCurso">Un entero que es id del Curso</param>
        /// <returns type="List<Alumno>">Devuelve un listado con los alumnos de un curso concreto</returns>
        public List<Alumno> getListadoAlumnosCurso(int idCurso)
        {
            List<Alumno> listadoAlumnosCurso = new List<Alumno>();
            Alumno alumno = null;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterIdCurso=new SqlParameter();
           
            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idAlumno, nombreAlumno, apellidosAlumno, idCurso, beca From Alumnos where idCurso=@idCurso";
                parameterIdCurso.ParameterName = "@idCurso";
                parameterIdCurso.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdCurso.Value = idCurso;
                sqlCommand.Parameters.Add(parameterIdCurso);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        alumno = new Alumno();
                        alumno.ID = (int)dataReader["idAlumno"];
                        alumno.Nombre = (string)dataReader["nombreAlumno"];
                        alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                        alumno.IdCurso = (int)dataReader["idCurso"];
                        if (dataReader["beca"] != System.DBNull.Value)
                        {
                            alumno.Beca = (decimal)dataReader["beca"];
                        }
                        listadoAlumnosCurso.Add(alumno);
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return listadoAlumnosCurso;
        }

    }
}
