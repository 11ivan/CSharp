using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
    Propiedades:
        Hereda de Alumno
        Nombre Curso: Cadena, Consultable, Modificable
     
*/

namespace Ejercicio1Examen.Models.ViewModels
{
    public class VMAlumnoConNombreCurso : Alumno
    {
        private string _nombreCurso;

        public VMAlumnoConNombreCurso() : base()
        {
            _nombreCurso = "";
        }

        public string NombreCurso
        {
            get
            {
                return _nombreCurso;
            }
            set
            {
                _nombreCurso = value;
            }
        }




    }
}