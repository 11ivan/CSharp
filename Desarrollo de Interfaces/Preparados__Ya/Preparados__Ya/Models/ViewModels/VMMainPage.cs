using _19_BindingListaPersonas.Models.ViewModel;
using Preparados__Ya.Models.Entities;
using Preparados__Ya.Models.Lists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades Básicas:

     
Propiedades Agregadas:
    
    Lista de productos Original: ListaProductos, No Consultable, No Modificable.
    Lista de productos para Bindear a la Vista: ObservableCollection<Productos>, Consultable, Modificable.
    Producto Seleccionado: Producto, Consultable, Modificable.
    
*/


namespace Preparados__Ya.Models.ViewModels
{


    public class VMMainPage: clsVMBase
    {

        #region Propiedades

        private ListaProductos _listaProductosOriginal;
        private ObservableCollection<Producto> _listaProductosBinding;
        private Producto _productoSeleccionado;

        #endregion Propiedades

    /// /////////////////////////////////////////////////////////////////////////

        #region Constructores

        public VMMainPage()
        {
            _listaProductosOriginal = new ListaProductos();
            _listaProductosBinding = new ObservableCollection<Producto>();
            //_productoSeleccionado = new Producto();

            _listaProductosOriginal.cargaProductos();
            //Cargar lista Bindeada con los elementos de la lista original//
            cargaListaBindeada();
        }

        #endregion Constructores

    /// /////////////////////////////////////////////////////////////////////////

        #region Getters and Setters

        public ObservableCollection<Producto> ListaProductosBinding
        {
            get
            {
                return _listaProductosBinding;
            }
        }

        public Producto ProductoSeleccionado
        {
            get
            {
                return _productoSeleccionado;
            }
            set
            {
                _productoSeleccionado = value;
                NotifyPropertyChanged("ProductoSeleccionado");
            }
        }

        #endregion Getters and Setters

    /// /////////////////////////////////////////////////////////////////////////

        #region Métodos de Clase


        public void cargaListaBindeada()
        {
            foreach (Producto p  in _listaProductosOriginal.listaProductos)
            {
                //Si la lista bindeada contiene elementos
                if (_listaProductosBinding.Count>0)
                {
                    //Si el Producto no existe ya en la Lista Bindeada
                    if (!_listaProductosBinding.Contains(p))
                    {
                        _listaProductosBinding.Add(p);
                    }
                }
                else
                {
                    _listaProductosBinding.Add(p);
                }
            }
        }



        #endregion Métodos de Clase

        /// /////////////////////////////////////////////////////////////////////////











    }
}
