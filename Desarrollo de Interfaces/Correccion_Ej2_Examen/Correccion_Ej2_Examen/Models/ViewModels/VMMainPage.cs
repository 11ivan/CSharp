using Correccion_Ej2_Examen.Models.ViewModel;
using Correccion_Ej2_Examen.Models.Entities;
using Correccion_Ej2_Examen.Models.Lists;
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
    Lista Bindeada de Alumnos: ObservableCollection<Alumno>, consultable, modificable 
*/

namespace Correccion_Ej2_Examen.Models.ViewModels
{
    public class VMMainPage:clsVMBase
    {

        private ListaCursos _listaCursos;
        private ListaAlumnos _listaAlumnos;
        private Curso _cursoSeleccionado;
        private ListaAlumnos _listaAlumnosCompleta;


        public VMMainPage()
        {
            _listaCursos = new ListaCursos();
            _listaAlumnos = new ListaAlumnos();
            _listaCursos.cargaCursos();
            _listaAlumnosCompleta = new ListaAlumnos();
            _listaAlumnosCompleta.cargaAlumnos();
        }


        #region Getters and Setters
        public ObservableCollection<Curso> ListaCursos
        {
            get
            {
                return _listaCursos.ListadoCursos;
            }
        }

        public ObservableCollection<Alumno> ListaAlumnos
        {
            get
            {
                return _listaAlumnos.ListadoAlumnos;
            }
            set
            {
                _listaAlumnos.ListadoAlumnos = value;
            }
        }

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
                    filtraAlumnos();
                }    
            }
        }
            
        #endregion Getters and Setters


        #region Métodos de Clase
        /// <summary>
        /// Carga en la lista de Alumnos bindeada los alumnos del curso seleccionado en la lista Bindeada
        /// </summary>
        public void filtraAlumnos()
        {
            //Forma 1 
            /*List<Alumno> listApoyo = new List<Alumno>();

            foreach (Alumno alumnoTemp in _listaAlumnosCompleta.ListadoAlumnos)
            {
                if (alumnoTemp.IdCurso == _cursoSeleccionado.IdCurso)
                {
                    listApoyo.Add(alumnoTemp);
                }
            }

            _listaAlumnos.ListadoAlumnos = new ObservableCollection<Alumno>(listApoyo);*/

            //Forma 2
            _listaAlumnos = new ListaAlumnos();

            if (_cursoSeleccionado.IdCurso==1)
            {
                _listaAlumnos.cargaAlumnosPrimero();
            }
            else
            {
                _listaAlumnos.cargaAlumnosSegundo();
            }

            NotifyPropertyChanged("ListaAlumnos");
        }

       

        #endregion Métodos de Clase

    }
}
