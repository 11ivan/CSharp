using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    [idAlumno] [int] IDENTITY(1,1) NOT NULL,
	[nombreAlumno] [varchar](20) NOT NULL,
	[apellidosAlumno] [varchar](50) NOT NULL,
	[idCurso] [int] NULL,
	[beca] [money] NULL,
    
    Propiedades Básicas:
        Id: Entero, Consultable, Modificable
        Nombre: Cadena, Consultable, Modificable
        Apellidos: Cadena, Consultable, Modificable
        idCurso: Entero, Consultable, Modificable
        Beca: Decimal, Consultable, Modificable
     
*/
namespace Entidades
{
    public class Alumno
    {
        #region Propiedades

        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _idCurso;
        private Decimal _beca;

        #endregion Propiedades

        #region Constructores
        public Alumno()
        {
            _id = 0;
            _nombre = "";
            _apellidos = "";
            _idCurso = 0;
            _beca = 0;
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

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        public int IdCurso
        {
            get
            {
                return _idCurso;
            }
            set
            {
                _idCurso = value;
            }
        }

        public Decimal Beca
        {
            get
            {
                return _beca;
            }
            set
            {
                _beca = value;
            }
        }

        #endregion Getters and Setters


    }
}
