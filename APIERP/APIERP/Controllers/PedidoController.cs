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
        public void Post()
        {
            GestoraPedidosBL gestoraPedidosBL = new GestoraPedidosBL();
            PedidoConLineaPedido pedidoConLinea = new PedidoConLineaPedido();
            LineaPedido lineaPedido = new LineaPedido();
            lineaPedido.IDProducto = 10;
            lineaPedido.Cantidad = 10;
            lineaPedido.PrecioVenta = 50;

            pedidoConLinea.IDCliente = 1;
            pedidoConLinea.LineasPedido.Add(lineaPedido);
            try
            {
                gestoraPedidosBL.insertPedido(pedidoConLinea);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
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
