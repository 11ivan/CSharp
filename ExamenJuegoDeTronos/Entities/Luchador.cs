using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Luchador
    {
        #region Propiedades

        private int _id;
        private String _nombre;
        private int _idCasa;

        #endregion Propiedades

        #region Constructores
        public Luchador()
        {
            _id = 0;
            _nombre = "";
            _idCasa = 0;
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
        public int IDCasa
        {
            get
            {
                return _idCasa;
            }
            set
            {
                this._idCasa = value;
            }
        }
        #endregion Getters and Setters

    }
}
