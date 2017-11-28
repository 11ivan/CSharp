using Capa_DAL.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
*/

namespace Capa_DAL.Listados
{
    public class ListadoAlumnosDAL
    {

        /// <summary>
        /// Ofrece un listado con los alumnos de la base de datos
        /// </summary>
        /// <returns>List<Alumno></returns>
        public List<Alumno> getListadoAlumnos()
        {
            List<Alumno> listadoAlumnos = new List<Alumno>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            /* [idAlumno] [int] IDENTITY(1,1) NOT NULL,
	            [nombreAlumno] [varchar](20) NOT NULL,
	            [apellidosAlumno] [varchar](50) NOT NULL,
	            [idCurso] [int] NULL,
	            [beca]*/
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select idAlumno, nombreAlumno, apellidosAlumno, idCurso, beca from Alumnos";
                sqlCommand.Connection = conexion.connection;
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.ID = (int)dataReader["idAlumno"];
                        alumno.Nombre = (string)dataReader["nombreAlumno"];
                        alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                        alumno.IdCurso = (int)dataReader["idCurso"];
                        alumno.Beca = (System.Decimal)dataReader["beca"];
                        listadoAlumnos.Add(alumno);
                    }
                }

                conexion.connection.Close();
                dataReader.Close();
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
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterNombreCurso=new SqlParameter();
            /* [idAlumno] [int] IDENTITY(1,1) NOT NULL,
	            [nombreAlumno] [varchar](20) NOT NULL,
	            [apellidosAlumno] [varchar](50) NOT NULL,
	            [idCurso] [int] NULL,
	            [beca]*/
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select A.idAlumno, A.nombreAlumno, A.apellidosAlumno, A.idCurso, A.beca from Alumnos as A inner join" +
                                         " Cursos as C on A.idAlumno=C.idCurso where C.nombreCurso=@nombreCurso";
                sqlCommand.Connection = conexion.connection;
                parameterNombreCurso.ParameterName = "@nombreCurso";
                parameterNombreCurso.SqlDbType = System.Data.SqlDbType.NVarChar;
                parameterNombreCurso.Value = nombreCurso;
                sqlCommand.Parameters.Add(parameterNombreCurso);
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.ID = (int)dataReader["idAlumno"];
                        alumno.Nombre = (string)dataReader["nombreAlumno"];
                        alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                        alumno.IdCurso = (int)dataReader["idCurso"];
                        if (dataReader["beca"] != System.DBNull.Value)
                        {
                            alumno.Beca = (System.Decimal)dataReader["beca"];
                        }
                        else
                        {
                            alumno.Beca = 0;
                        }
                        listadoAlumnos.Add(alumno);
                    }
                }

                conexion.connection.Close();
                dataReader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoAlumnos;
        }


    }
}
