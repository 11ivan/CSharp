using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Propiedades:
        ID: Entero, Consultable, Modificable
        Nombre: Cadena, Consultable, Modificable
        Apellidos: Cadena, Consultable, Modificable
        Beca: Decimal, Consultable, Modificable
        Id del Curso: Entero, Consultable, Modificable
*/

namespace Entidades
{
    public class Alumno
    {
        #region Propiedades

        private int _id;
        private string _nombre;
        private string _apellidos;
        private decimal _beca;
        private int _idCurso;

        #endregion Propiedades

        public Alumno()
        {
            _id = -1;
            _nombre = "";
            _apellidos = "";
            _beca = 0;
            _idCurso = -1;
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

        [Required(ErrorMessage ="La beca no puede estar en blanco")]
        [DataType(DataType.Currency, ErrorMessage ="Solo se permiten números")]
        public decimal Beca
        {
            get
            {
                return Decimal.Round(_beca, 2);
            }
            set
            {
                _beca = value;
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

        #endregion Getters and Setters

    }
}
