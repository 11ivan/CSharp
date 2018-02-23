using CapaDAL.Connection;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Gestoras
{
    public class GestoraCategoriasPremiosDAL
    {
        /// <summary>
        /// Devuelve un listado con las categorias de los premios de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPremio> getListaCategoriasPremios()
        {
            List<CategoriaPremio> listadoCategoriasPremios = new List<CategoriaPremio>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            CategoriaPremio categoriaPremio;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idCategoriaPremio, nombreCategoriaPremio From categoriasPremios";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        categoriaPremio = new CategoriaPremio();
                        categoriaPremio.ID = (int)dataReader["idCategoriaPremio"];
                        categoriaPremio.Nombre = (string)dataReader["nombreCategoriaPremio"];
                        listadoCategoriasPremios.Add(categoriaPremio);
                    }
                }
                dataReader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.connection.Close();
            }
            return listadoCategoriasPremios;
        }

    }
}
