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
        /// Inserta un nuevo pedido en la base de datos
        /// </summary>
        /// <param name="pedidoConLineaPedido"></param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int insertPedido(PedidoConLineaPedido pedidoConLineaPedido)
        {
            int affectedRows = 0;
            int idPedidoInsertado = -1;
            SqlCommand sqlCommand;
            Conexion conexion = new Conexion();
            SqlParameter parameterIdCliente=new SqlParameter();
            SqlParameter parameterFecha = new SqlParameter();
            SqlParameter parameterPrecioTotal = new SqlParameter();
            SqlParameter parameterOutPut = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand=new SqlCommand("NombreProcedure", conexion.connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                parameterIdCliente.ParameterName = "@idCliente";
                parameterIdCliente.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdCliente.Value = pedidoConLineaPedido.IDCliente;

                /*parameterFecha.ParameterName = "@fecha";
                parameterFecha.SqlDbType = System.Data.SqlDbType.DateTime;
                parameterFecha.Value = pedidoConLineaPedido.Fecha;

                parameterPrecioTotal.ParameterName = "@precioTotal";
                parameterPrecioTotal.SqlDbType = System.Data.SqlDbType.Decimal;
                parameterPrecioTotal.Value = Decimal.Round(pedidoConLineaPedido.PrecioTotal, 2);*/

                parameterOutPut.ParameterName = "@ID_Pedido";
                parameterOutPut.SqlDbType = System.Data.SqlDbType.Int;
                parameterOutPut.Direction = System.Data.ParameterDirection.Output;

                sqlCommand.Parameters.Add(parameterIdCliente);
                //sqlCommand.Parameters.Add(parameterFecha);
                //sqlCommand.Parameters.Add(parameterPrecioTotal);
                sqlCommand.Parameters.Add(parameterOutPut);

                affectedRows = sqlCommand.ExecuteNonQuery();
                idPedidoInsertado= Convert.ToInt32(sqlCommand.Parameters["@ID_Pedido"].Value);



                //

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
