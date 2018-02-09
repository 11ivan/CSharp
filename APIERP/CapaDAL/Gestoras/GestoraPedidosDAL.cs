using CapaDAL.GestoraConexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Gestoras
{
    public class GestoraPedidosDAL
    {

        /// <summary>
        /// Inserta un nuevo pedido en la base de datos y todas sus Lineas de pedido
        /// </summary>
        /// <param name="pedidoConLineaPedido"></param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int insertPedido(PedidoConLineaPedido pedidoConLineaPedido)
        {
            int affectedRows = 0;
            int idPedidoInsertado = -1;
            SqlCommand sqlCommandInsertPedido;
            SqlCommand sqlCommandInsertLineaPedido;
            Conexion conexion = new Conexion();
            SqlParameter parameterIdCliente=new SqlParameter();
            SqlParameter parameterCantidad = new SqlParameter();
            SqlParameter parameterPrecioVenta = new SqlParameter();
            SqlParameter parameterIdProducto = new SqlParameter();
            SqlParameter parameterIdPedido = new SqlParameter();
            SqlParameter parameterOutPut = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommandInsertPedido = new SqlCommand("InsertarPedido", conexion.connection);//Nombre
                sqlCommandInsertPedido.CommandType = System.Data.CommandType.StoredProcedure;

                parameterIdCliente.ParameterName = "@ID_Cliente";
                parameterIdCliente.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdCliente.Value = pedidoConLineaPedido.IDCliente;

                parameterOutPut.ParameterName = "@ID_Pedido";
                parameterOutPut.SqlDbType = System.Data.SqlDbType.Int;
                parameterOutPut.Direction = System.Data.ParameterDirection.Output;

                sqlCommandInsertPedido.Parameters.Add(parameterIdCliente);
                sqlCommandInsertPedido.Parameters.Add(parameterOutPut);

                //Llamada a procedimento para insertar pedido
                affectedRows = sqlCommandInsertPedido.ExecuteNonQuery();
                idPedidoInsertado = Convert.ToInt32(sqlCommandInsertPedido.Parameters["@ID_Pedido"].Value);

                //Parametros para llamada a aprocedimiento para insertar lineas de pedido
                sqlCommandInsertLineaPedido = new SqlCommand("InsertarLineaPedido", conexion.connection);//Nombre
                sqlCommandInsertLineaPedido.CommandType = System.Data.CommandType.StoredProcedure;

                parameterCantidad.ParameterName = "@Cantidad";
                parameterCantidad.SqlDbType = System.Data.SqlDbType.Int;

                parameterPrecioVenta.ParameterName = "@PrecioVenta";
                parameterPrecioVenta.SqlDbType = System.Data.SqlDbType.Decimal;

                parameterIdProducto.ParameterName = "@ID_Producto";
                parameterIdProducto.SqlDbType = System.Data.SqlDbType.Int;

                parameterIdPedido.ParameterName = "@ID_Pedido";
                parameterIdPedido.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdPedido.Value = idPedidoInsertado;

                //Bucle para insertar las distintas lineas del pedido
                for (int i=0;i<pedidoConLineaPedido.LineasPedido.Count;i++)
                {
                    //Llamada a procedimiento para insertar cada linea de pedido
                    //IdPedido, idProducto, Cantidad, PrecioVenta
                    parameterIdProducto.Value = pedidoConLineaPedido.LineasPedido.ElementAt(i).IDProducto;
                    parameterPrecioVenta.Value = Math.Round(pedidoConLineaPedido.LineasPedido.ElementAt(i).PrecioVenta, 2);
                    parameterCantidad.Value = pedidoConLineaPedido.LineasPedido.ElementAt(i).Cantidad;

                    sqlCommandInsertLineaPedido.Parameters.Add(parameterIdPedido);
                    sqlCommandInsertLineaPedido.Parameters.Add(parameterIdProducto);
                    sqlCommandInsertLineaPedido.Parameters.Add(parameterCantidad);
                    sqlCommandInsertLineaPedido.Parameters.Add(parameterPrecioVenta);

                    affectedRows=affectedRows + sqlCommandInsertLineaPedido.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.connection.Close();
            }
            return affectedRows;
        }




    }
}
