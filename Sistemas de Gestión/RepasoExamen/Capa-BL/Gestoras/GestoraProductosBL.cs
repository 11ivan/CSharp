using Capa_DAL.Gestoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraProductosBL
    {

        /// <summary>
        /// Recibe el id de un producto, hace una consulta a la base de datos y devuelve el producto asciado al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producto getProducto(int id)
        {
            Producto producto;
            GestoraProductosDAL gestoraProductosDAL = new GestoraProductosDAL();
            producto = gestoraProductosDAL.getProducto(id);
            return producto;
        }

        /// <summary>
        /// Inserta un producto en la base de datos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public int insertProduct(Producto producto)
        {
            int affectedRows = 0;
            GestoraProductosDAL gestoraProductosDAL = new GestoraProductosDAL();
            try
            {
                affectedRows = gestoraProductosDAL.insertProduct(producto);
            }catch(Exception e)
            {
                throw e;
            }

            return affectedRows;
        }


    }
}
