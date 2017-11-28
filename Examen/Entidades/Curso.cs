using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombreCurso] [varchar](50) NULL,
    
    Propiedades Básicas:
        Id: Entero, Consultable, Modificable
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

        #region Constructores
        public Curso()
        {
            _id = 0;
            _nombre = "";
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
