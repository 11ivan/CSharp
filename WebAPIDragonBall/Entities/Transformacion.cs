using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Transformacion
    {
        #region Propiedades

        private int _id;
        private String _nombre;
        private String _rutaImagen;
        private int _idPersonaje;

        #endregion Propiedades

        #region Constructores
        public Transformacion()
        {
            _id = 0;
            _nombre = "";
            _rutaImagen = "";
            _idPersonaje = 0;
        }

        public Transformacion(int id, String nombre, String rutaImagen, int idPersonaje)
        {
            this._id = id;
            this._nombre = nombre;
            this._rutaImagen = rutaImagen;
            this._idPersonaje = idPersonaje;
        }

        #endregion Constructores

        #region Getters and Setters

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
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
                this._nombre = value;
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
                this._rutaImagen = value;
            }
        }
        public int IdPersonaje
        {
            get
            {
                return _idPersonaje;
            }
            set
            {
                this._idPersonaje = value;
            }
        }
        #endregion Getters and Setters






    }
}
