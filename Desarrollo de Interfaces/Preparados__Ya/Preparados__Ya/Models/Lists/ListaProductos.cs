using Preparados__Ya.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Propiedades Agregadas:
        Lista de Productos: List<Producto>, Consultable, Modificable
    
*/

namespace Preparados__Ya.Models.Lists
{

    public class ListaProductos
    {
        #region Propiedades

        private List<Producto> _listaProductos;

        #endregion Propiedades

    //////////////////////////////////////////////////////////////

        #region Constructores

        public ListaProductos()
        {
            _listaProductos = new List<Producto>();
        }

        #endregion Constructores

    //////////////////////////////////////////////////////////////

        #region Getters and Setters

        public List<Producto> listaProductos
        {
            get
            {
                return _listaProductos;
            }
        }

        #endregion Getters and Setters

    /////////////////////////////////////////////////////////////

        #region Métodos de Clase

        public void cargaProductos()
        {
            Producto producto1 = new Producto("Cola-Cao", "1.85", "Envase Plástico 350gr.", "ms-appx:///assets/Images/colacao.jpg");
            Producto producto2 = new Producto("Agua Lanjarón", "0.75", "Envase Plástico 1.5L .", "ms-appx:///assets/Images/lanjaron.jpg");
            Producto producto3 = new Producto("Botellines Cruzcampo", "9.85", "Pack de 24 300ml.", "ms-appx:///assets/Images/cruzcampo.jpg");
            _listaProductos.Add(producto1);
            _listaProductos.Add(producto2);
            _listaProductos.Add(producto3);
        }

        #endregion Métodos de Clase














    }
}
