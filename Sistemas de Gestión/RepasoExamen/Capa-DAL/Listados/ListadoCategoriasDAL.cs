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
    public class ListadoCategoriasDAL
    {


        /// <summary>
        /// Ofrece un listado con las categorias disponibles en la base de datos
        /// </summary>
        /// <returns>List<Categoria></returns>
        public List<Categoria> getListadoCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand=new SqlCommand();
            SqlDataReader dataReader;
            Categoria categoria;
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select id, Nombre From Categorias";
                sqlCommand.Connection = conexion.connection;
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        categoria = new Categoria();
                        categoria.ID = (int)dataReader["id"];
                        categoria.Nombre = (string)dataReader["Nombre"];
                        listaCategorias.Add(categoria);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaCategorias;
        }









    }
}
