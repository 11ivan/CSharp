using Capa_DAL.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraCursosDAL
    {

        /// <summary>
        /// Dado un id de curso realiza una consulta a la base de datos y devuelve el nombre del curso asociado al id
        /// </summary>
        /// <param name="idCurso">Un entero que es el id del curso</param>
        /// <returns>Devuelve una cadena que es el nombre del curso</returns>
        public string getNombreCurso(int idCurso)
        {
            string nombreCurso = "";
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterIdCurso = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select nombreCurso From Cursos where idCurso=@idCurso";
                parameterIdCurso.ParameterName = "@idCurso";
                parameterIdCurso.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdCurso.Value = idCurso;
                sqlCommand.Parameters.Add(parameterIdCurso);
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    nombreCurso = (string)dataReader["nombreCurso"];
                }

                dataReader.Close();
                conexion.connection.Close();
            }catch(Exception e)
            {
                throw e;
            }

            return nombreCurso;
        }

    }
}
