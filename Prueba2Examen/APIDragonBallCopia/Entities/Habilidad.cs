using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Habilidad
    {
        #region Propiedades

        private int _id;
        private String _nombre;
        private int _poder;
        private int _idPersonaje;

        #endregion Propiedades

        #region Constructores
        public Habilidad()
        {
            _id = 0;
            _nombre = "";
            _poder = 0;
            _idPersonaje = 0;
        }

        public Habilidad(int id, String nombre, int poder, int idPersonaje)
        {
            this._id = id;
            this._nombre = nombre;
            this._poder = poder;
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
        public int Poder
        {
            get
            {
                return _poder;
            }
            set
            {
                this._poder = value;
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
