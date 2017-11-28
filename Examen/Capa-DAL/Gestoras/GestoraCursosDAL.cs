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
    public class GestoraCursosDAL
    {

        /// <summary>
        /// Recibe el id de un curso, hace una consulta a la base de datos con ese id y devuelve el curso asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Curso</returns>
        public Curso getCurso(int id)
        {
            Curso curso = new Curso();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterID = new SqlParameter();
            SqlDataReader dataReader;
            /*	[idCurso] [int] IDENTITY(1,1) NOT NULL,
                [nombreCurso] [varchar](50) NULL,
            */
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select idCurso, nombreCurso from Cursos where idCurso=@id";
                sqlCommand.Connection = conexion.connection;
                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    curso.ID = (int)dataReader["idCurso"];
                    curso.Nombre = (string)dataReader["nombreCurso"];
                }
                conexion.connection.Close();
                dataReader.Close();
            }      
            catch (Exception e)
            {
                throw e;
            }
            return curso;
        }


    }
}
