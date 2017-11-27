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
    public class GestoraProductosDAL
    {

        /// <summary>
        /// Recibe un id, realiza una consulta a la base de datos con el id y devuelve el Producto asociado
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        public Producto getProducto(int idProducto)
        {
            Conexion conexion = new Conexion();
            Producto producto = new Producto(); ;
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameter = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "Select id, Nombre, Precio, idCategoria from Productos where id=@id";
                sqlCommand.Connection = conexion.connection;
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = idProducto;
                sqlCommand.Parameters.Add(parameter);

                dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    producto.ID = (int)dataReader["id"];
                    producto.Nombre = (string)dataReader["Nombre"];
                    producto.Precio = (Decimal)dataReader["Precio"];
                    producto.IdCategoria = (int)dataReader["idCategoria"];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return producto;
        }

        /// <summary>
        /// Inserta un producto en la base de datos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns>Devuelve un entero con el número de filas afectadas</returns>
        public int insertProduct(Producto producto)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterNombre = new SqlParameter();
            SqlParameter parameterPrecio = new SqlParameter();
            SqlParameter parameterIdCategoria = new SqlParameter();
            try
            {
                conexion.openConnection();
                sqlCommand.CommandText = "INSERT INTO Productos(Nombre, Precio, idCategoria) VALUES (@nombre, @precio, @idCategoria)";
                sqlCommand.Connection = conexion.connection;
                parameterNombre.ParameterName = "@nombre";
                parameterNombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                parameterNombre.Value = producto.Nombre;
                parameterPrecio.ParameterName = "@precio";
                parameterPrecio.SqlDbType = System.Data.SqlDbType.Decimal;
                parameterPrecio.Value = producto.Precio;
                parameterIdCategoria.ParameterName = "@idCategoria";
                parameterIdCategoria.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdCategoria.Value = producto.IdCategoria;
                sqlCommand.Parameters.Add(parameterNombre);
                sqlCommand.Parameters.Add(parameterPrecio);
                sqlCommand.Parameters.Add(parameterIdCategoria);
                affectedRows=sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            return affectedRows;
        }



    }
}
