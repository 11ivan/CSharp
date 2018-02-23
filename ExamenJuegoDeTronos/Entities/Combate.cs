using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Combate
    {
        #region Propiedades

        private int _id;
        private DateTime _fechaCombate;

        #endregion Propiedades

        #region Constructores
        public Combate()
        {
            _id = 0;
            _fechaCombate = new DateTime();
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

        public DateTime FechaCombate
        {
            get
            {
                return _fechaCombate;
            }
            set
            {
                this._fechaCombate = value;
            }
        }

        #endregion Getters and Setters


    }
}
