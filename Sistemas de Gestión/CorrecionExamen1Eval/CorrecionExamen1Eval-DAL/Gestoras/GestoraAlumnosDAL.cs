using Capa_DAL.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraAlumnosDAL
    {

        /// <summary>
        /// Dado un id de Alumno realiza una consulta a la tabla Alumnos de la base de datos y devuelve el alumno asociado al id
        /// </summary>
        /// <param name="idAlumno">Un entero que es el id del Alumno</param>
        /// <returns>Devuelve un Alumno</returns>
        public Alumno getAlumno(int idAlumno)
        {
            Alumno alumno = null;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterIdAlumno = new SqlParameter();
            SqlDataReader dataReader;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idAlumno, nombreAlumno, apellidosAlumno, idCurso, beca From Alumnos where idAlumno=@idAlumno";

                parameterIdAlumno.ParameterName = "@idAlumno";
                parameterIdAlumno.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdAlumno.Value = idAlumno;

                sqlCommand.Parameters.Add(parameterIdAlumno);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    alumno = new Alumno();
                    alumno.ID = (int)dataReader["idAlumno"];
                    alumno.Nombre = (string)dataReader["nombreAlumno"];
                    alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                    alumno.IdCurso = (int)dataReader["idCurso"];
                    if (dataReader["beca"] != System.DBNull.Value)
                    {
                        alumno.Beca = (decimal)dataReader["beca"];
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
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
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            int affectedRows = 0;
            SqlParameter parameterIdAlumno = new SqlParameter();
            SqlParameter parameterImporteBeca = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Update Alumnos set beca=@importeBeca where idAlumno=@idAlumno";

                parameterIdAlumno.ParameterName = "@idAlumno";
                parameterIdAlumno.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdAlumno.Value = idAlumno;

                parameterImporteBeca.ParameterName = "@importeBeca";
                parameterImporteBeca.SqlDbType = System.Data.SqlDbType.Decimal;
                parameterImporteBeca.Value = importeBeca;

                sqlCommand.Parameters.Add(parameterIdAlumno);
                sqlCommand.Parameters.Add(parameterImporteBeca);

                affectedRows = sqlCommand.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return affectedRows;
        }

    }
}
