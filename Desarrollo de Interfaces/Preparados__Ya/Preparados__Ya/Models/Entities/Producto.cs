using _19_BindingListaPersonas.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Propiedades Básicas:

    Nombre: Cadena, Consultable, Modificable
    Precio: Cadena, Consultable, Modificable
    Descripción: Cadena, Consultable, Modificable
    Ruta de Imagen: Cadena, Consultable, Modificable

Propiedades Agregadas:

    ID: Guid, consultable, No Modifiicable
     
     
*/

namespace Preparados__Ya.Models.Entities
{
    public class Producto: clsVMBase
    {

        #region Propiedades

        private Guid _id;
        private String _nombre;
        private String _precio;
        private String _descripcion;
        private String _rutaImagen;

        #endregion Propiedades
/// /////////////////////////////////////////////////////////
        #region Constructores

        public Producto()
        {
            _id = Guid.NewGuid();
            _nombre = "";
            _precio = "";
            _descripcion = "";
            _rutaImagen = "";
        }

        public Producto(String nombre, String precio, String descripcion, String rutaImagen)
        {
            _id = Guid.NewGuid();
            _nombre = nombre;
            _precio = precio;
            _descripcion = descripcion;
            _rutaImagen = rutaImagen;
        }

        #endregion Constructores
        /// ///////////////////////////////////////////////////////////
        #region Getters and Setters

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        public String Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
                NotifyPropertyChanged("Precio");
            }
        }

        public String Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                NotifyPropertyChanged("Descripcion");
            }
        }

        public String RutaImagen
        {
            get
            {
                return _rutaImagen;
            }
            set
            {
                _rutaImagen = value;
                NotifyPropertyChanged("RutaImagen");
            }
        }

        #endregion Getters and Setters





    }
}
