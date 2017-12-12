using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Capa_DAL.Connection;
using System.Data.SqlClient;

namespace Capa_DAL.Listados
{
    public class ListadoCursosDAL
    {

        /// <summary>
        /// Ofrece un listado con los Cursos que hay en la tabla Cursos de la base de datos
        /// </summary>
        /// <returns>List<Curso></returns>
        public List<Curso> getListadoCursos()
        {
            List<Curso> listadoCursos = new List<Curso>();
            Curso curso = null;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;        

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idCurso, nombreCurso From Cursos";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        curso = new Curso();
                        curso.ID =(int) dataReader["idCurso"];
                        curso.Nombre = (string)dataReader["nombreCurso"];
                        listadoCursos.Add(curso);
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
            }catch(SqlException e)
            {
                throw e;
            }

            return listadoCursos;
        }

    }
}
