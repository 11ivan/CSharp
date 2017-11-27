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
    public class GestoraCategoriasDAL
    {

        /// <summary>
        /// Recibe un id, realiza una consulta a la base de datos con el id y devuelve la Categoria asociada
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns>Categoria</returns>
        public Categoria getCategoria(int idCategoria)
        {
            Conexion conexion = new Conexion();
            Categoria categoria = new Categoria(); ;
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameter = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select id, Nombre from Categorias where id=@id";
                sqlCommand.Connection = conexion.connection;
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = idCategoria;
                sqlCommand.Parameters.Add(parameter);

                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    categoria.ID = (int)dataReader["id"];
                    categoria.Nombre = (string)dataReader["Nombre"];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return categoria;
        }




    }
}
