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
    public class ListadoProductosDAL
    {

        /// <summary>
        /// Ofrece un listado con los productos de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Producto> getListadoProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Entidades.Producto producto;
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select id, Nombre, Precio, idCategoria From Productos";
                sqlCommand.Connection = conexion.connection;
                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        producto = new Producto();
                        producto.ID = (int)dataReader["id"];
                        producto.Nombre = (string)dataReader["Nombre"];
                        producto.Precio = (Decimal)dataReader["Precio"];
                        producto.IdCategoria = (int)dataReader["idCategoria"];
                        listaProductos.Add(producto);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaProductos;
        }


    }
}
