using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Personaje
    {

        #region Propiedades

        private int _id;
        private String _nombre;

        #endregion Propiedades

        #region Constructores
        public Personaje()
        {
            _id = 0;
            _nombre = "";
        }

        public Personaje(int id, String nombre)
        {
            this._id = id;  
            this._nombre = nombre;
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

        #endregion Getters and Setters


        


    }
}
