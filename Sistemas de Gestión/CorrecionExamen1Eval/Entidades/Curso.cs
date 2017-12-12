using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Propiedades:
        ID: Entero, Consultable, Modificable
        Nombre: Cadena, Consultable, Modificable
*/


namespace Entidades
{
    public class Curso
    {
        #region Propiedades

        private int _id;
        private string _nombre;

        #endregion Propiedades


        public Curso()
        {
            _id = -1;
            _nombre = "";
        }


        #region Getters and Setters
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        #endregion Getters and Setters


    }
}
