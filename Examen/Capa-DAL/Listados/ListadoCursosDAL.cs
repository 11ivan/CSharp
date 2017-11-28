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
    public class ListadoCursosDAL
    {

        /// <summary>
        /// Ofrece un listado con los cursos de la base de datos
        /// </summary>
        /// <returns>List<Curso></returns>
        public List<Curso> getListadoCursos()
        {
            List<Curso> listadoCursos = new List<Curso>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            /*	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	            [nombreCurso] [varchar](50) NULL,
            */
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select idCurso, nombreCurso from Cursos";
                sqlCommand.Connection = conexion.connection;
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Curso curso = new Curso();
                        curso.ID = (int)dataReader["idCurso"];
                        curso.Nombre = (string)dataReader["nombreCurso"];
                        listadoCursos.Add(curso);
                    }
                }
                conexion.connection.Close();
                dataReader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoCursos;
        }


    }
}
