using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
    Propiedades:
        Extiende de Alumno.
        Nombre del Curso: Cadena, Consultable, Modificable
     
*/

namespace CorrecionExamen1Eval_UI.Models.ViewModels
{
    public class VMAlumnoConNombreCurso:Alumno
    {

        #region Propiedades
        private string _nombreCurso;

        #endregion Propiedades


        #region Constructores
        public VMAlumnoConNombreCurso():base()
        {
            _nombreCurso = "";
        }

        #endregion Constructores


        #region Getters and Setters

        [Display(Name="Curso")]
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


        #endregion Getters and Setters

    }
}