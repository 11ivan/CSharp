using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClasificacionCombate
    {
        #region Propiedades

        private int _id;
        private int _puntos;
        private int _idCategoriaPremio;
        private int _idLuchador;

        #endregion Propiedades

        #region Constructores
        public ClasificacionCombate()
        {
            _id = 0;
            _puntos = 0;
            _idCategoriaPremio = 0;
            _idLuchador = 0;
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

        public int Puntos
        {
            get
            {
                return _puntos;
            }
            set
            {
                this._puntos = value;
            }
        }
        public int IDCategoriaPremio
        {
            get
            {
                return _idCategoriaPremio;
            }
            set
            {
                this._idCategoriaPremio = value;
            }
        }
        public int IDLuchador
        {
            get
            {
                return _idLuchador;
            }
            set
            {
                this._idLuchador = value;
            }
        }
        #endregion Getters and Setters



    }
}
