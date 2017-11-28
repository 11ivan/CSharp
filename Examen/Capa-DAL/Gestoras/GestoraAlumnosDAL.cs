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
        /// Recibe el id de un alumno, hace una consulta a la base de datos con ese id y devuelve el alumno asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alumno</returns>
        public Alumno getAlumno(int id)
        {
            Alumno alumno = new Alumno();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterID = new SqlParameter();
            SqlDataReader dataReader;
            /* [idAlumno] [int] IDENTITY(1,1) NOT NULL,
	            [nombreAlumno] [varchar](20) NOT NULL,
	            [apellidosAlumno] [varchar](50) NOT NULL,
	            [idCurso] [int] NULL,
	            [beca]*/
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select idAlumno, nombreAlumno, apellidosAlumno, idCurso, beca from Alumnos where idAlumno=@id";
                sqlCommand.Connection = conexion.connection;
                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    alumno.ID = (int)dataReader["idAlumno"];
                    alumno.Nombre = (string)dataReader["nombreAlumno"];
                    alumno.Apellidos = (string)dataReader["apellidosAlumno"];
                    alumno.IdCurso = (int)dataReader["idCurso"];
                    alumno.Beca = (Decimal)dataReader["beca"];
                }
                conexion.connection.Close();
                dataReader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return alumno;
        }



    }
}
