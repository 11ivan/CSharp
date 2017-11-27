using Capa_DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoProductosBL
    {

        public List<Producto> getListadoProductos()
        {
            List<Producto> listadoProductos = new List<Producto>();
            ListadoProductosDAL listadoProductosDAL = new ListadoProductosDAL();
            listadoProductos = listadoProductosDAL.getListadoProductos();
            return listadoProductos;
        }


    }
}
