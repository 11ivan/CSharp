using CapaBL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIERP.Controllers
{
    public class PedidoController : ApiController
    {
        // GET: api/Pedido
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedido
        public void Post([FromBody]PedidoConLineaPedido value)
        {
            GestoraPedidosBL gestoraPedidosBL = new GestoraPedidosBL();
            try
            {
                gestoraPedidosBL.insertPedido(value);
            }catch(Exception e)
            {
                throw e;
            }
        }

        //POST De Testeo
       /* public void Post()
        {
            GestoraPedidosBL gestoraPedidosBL = new GestoraPedidosBL();
            PedidoConLineaPedido pedidoConLinea = new PedidoConLineaPedido();
            LineaPedido lineaPedido = new LineaPedido();
            lineaPedido.IDProducto = 73;
            lineaPedido.Cantidad = 10;
            lineaPedido.PrecioVenta = 50;

            LineaPedido lineaPedido2 = new LineaPedido();
            lineaPedido2.IDProducto = 74;
            lineaPedido2.Cantidad = 10;
            lineaPedido2.PrecioVenta = 50;

            pedidoConLinea.IDCliente = 1;
            pedidoConLinea.LineasPedido.Add(lineaPedido);
            pedidoConLinea.LineasPedido.Add(lineaPedido2);
            try
            {
                gestoraPedidosBL.insertPedido(pedidoConLinea);
            }
            catch (Exception e)
            {
                throw e;
            }
        }*/

        // PUT: api/Pedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedido/5
        public void Delete(int id)
        {
        }
    }
}
