using _19_BindingListaPersonas.Models.ViewModel;
using Ejercicio2Examen.Models.Entities;
using Ejercicio2Examen.Models.Lists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades: 
    Lista de Alumnos: ListaAlumno, Consultable, Modificable
    Lista de Cursos: ListaCursos, Consultable, Modificable
    Curso Seleccionado: Curso, Consultable, Modificable
    AlumnoSeleccionado: Alumno, consultable, Modificable
    Lista Bindeada de Alumnos: ObservableCollection<Alumno>, consultable, modificable 
*/

namespace Ejercicio2Examen.Models.ViewModels
{
    public class VMMainPage:clsVMBase
    {
        private ListaCursos _listaCursos;
        private ListaAlumnos _listaAlumnos;
        private Curso _cursoSeleccionado;
        private Alumno _alumnoSeleccionado;
        private ObservableCollection<Alumno> _listaAlumnosBinding;


        public VMMainPage()
        {
            _listaCursos = new ListaCursos();
            _listaAlumnos = new ListaAlumnos();
            _listaCursos.cargaCursos();
            _listaAlumnos.cargaAlumnos();
            _listaAlumnosBinding = new ObservableCollection<Alumno>();
        }


        #region Getters and Setters
        public ObservableCollection<Curso> ListaCurso
        {
            get
            {
                return _listaCursos.ListadoCursos;
            }
        }

        /*public ObservableCollection<Alumno> ListaAlumno
        {
            get
            {
                return _listaAlumnos.ListadoAlumnos;
            }
        }*/

        public Curso CursoSeleccionado
        {
            get
            {
                return _cursoSeleccionado;
            }
            set
            {
                _cursoSeleccionado = value;
                if (_cursoSeleccionado!=null)
                {                  
                    cargaAlumnos();
                }    
            }
        }

        public Alumno AlumnoSeleccionado
        {
            get
            {
                return _alumnoSeleccionado;
            }
            set
            {
                _alumnoSeleccionado = value;
            }
        }


        public ObservableCollection<Alumno> ListaAlumnosBinding
        {
            get
            {
                return _listaAlumnosBinding;
            }
        }
        #endregion Getters and Setters

        #region Métodos de Clase

        /// <summary>
        /// Carga en el observableCollection de Alumnos los alumnos del curso seleccionado en la lista Bindeada
        /// </summary>
        public void cargaAlumnos()
        {
            borraAlumnos();
            for (int i=0;i<_listaAlumnos.ListadoAlumnos.Count;i++)
            {
                if (_listaAlumnos.ListadoAlumnos.ElementAt(i).IdCurso == _cursoSeleccionado.IdCurso)
                {
                    _listaAlumnosBinding.Add(_listaAlumnos.ListadoAlumnos.ElementAt(i));
                }
            }
        }

        /// <summary>
        /// Vacía el observableCollection de alumnos de la lista bindeada
        /// </summary>
        public void borraAlumnos()
        {
            for (int i = _listaAlumnosBinding.Count-1; i >= 0; i--)
            {        
                _listaAlumnosBinding.RemoveAt(i);
            }
        }

        #endregion Métodos de Clase

    }
}
