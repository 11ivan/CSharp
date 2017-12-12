using Capa_BL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrecionExamen1Eval_UI.Models.ViewModels
{
    public class VMListadoCursosConListadoAlumnosPorCurso
    {

        #region Propiedades

        private List<Curso> _listadoCursos;
        private List<Alumno> _listadoAlumnosCurso;
        private int _idCursoSeleccionado;//Esta propiedad la pongo porque uso dropDownListFor, si usara la etiqueta select con sus respectivas etiquetas option no necesitaria esta propiedad

        #endregion Propiedades

        #region Constructores

        public VMListadoCursosConListadoAlumnosPorCurso()
        {
            _listadoCursos = new List<Curso>();
            _listadoAlumnosCurso = new List<Alumno>();
            _idCursoSeleccionado = -1;
        }

        #endregion Constructores

        #region Getters and Setters

        public List<Curso> ListadoCursos
        {
            get
            {
                return _listadoCursos;
            }
            set
            {
                _listadoCursos = value;
            }
        }

        public List<Alumno> ListadoAlumnosCurso
        {
            get
            {
                return _listadoAlumnosCurso;
            }
            set
            {
                _listadoAlumnosCurso = value;
            }
        }

        public int IdCursoSeleccionado
        {
            get
            {
                return _idCursoSeleccionado;
            }
            set
            {
                _idCursoSeleccionado = value;
            }
        }

        #endregion Getters and Setters

        #region Metodos de clase

        /// <summary>
        /// Carga el listado de cursos con los cursos que hay en la tabla cursos de la base de datos
        /// </summary>
        public void cargaListadoCursos()
        {
            ListadoCursosBL listadoCursosBL = new ListadoCursosBL();
            try
            {
                _listadoCursos = listadoCursosBL.getListadoCursos();
            }
            catch (Exception e)
            {
                throw e;
            }

            #endregion Metodos de clase

        }

        /// <summary>
        /// Carga el listado de alumnos por curso con los alumnos de un curso concreto de la tabla Alumnos de la base de dato
        /// </summary>
        /// <param name="idCurso">Un entero que es el id del curso</param>
        public void cargaListadoAlumnosCurso(int idCurso)
        {
            ListadoAlumnosBL listadoAlumnosBL = new ListadoAlumnosBL();

            try
            {
                _listadoAlumnosCurso = listadoAlumnosBL.getListadoAlumnosCurso(idCurso);
            }
            catch (Exception e)
            {
                throw e;
            }
        }





    }
}