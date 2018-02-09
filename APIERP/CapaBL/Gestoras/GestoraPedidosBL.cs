using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraPedidosBL
    {

        /// <summary>
        /// Inserta un nuevo pedido en la base de datos y todas sus Lineas de pedido
        /// </summary>
        /// <param name="pedidoConLineaPedido"></param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int insertPedido(PedidoConLineaPedido pedidoConLineaPedido)
        {
            int affectedRows = 0;
            GestoraPedidosDAL gestoraPedidoDAL = new GestoraPedidosDAL();    

            try
            {
                affectedRows = gestoraPedidoDAL.insertPedido(pedidoConLineaPedido);
            }
            catch (Exception e)
            {
                throw e;
            }

            return affectedRows;
        }

    }
}
