using Correccion_Ej2_Examen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades:
    Lista de Alumnos: ObservableCollection<alumno>, consultable, modificable

*/

namespace Correccion_Ej2_Examen.Models.Lists
{

    public class ListaAlumnos
    {
        private ObservableCollection<Alumno> _listaAlumnos;

        public ListaAlumnos()
        {
            _listaAlumnos = new ObservableCollection<Alumno>();
        }


        public ObservableCollection<Alumno> ListadoAlumnos
        {
            get
            {
                return _listaAlumnos;
            }
            set
            {
                _listaAlumnos = value;
            }
        }

        /// <summary>
        /// Carga algunos alumnos de primero en la lista Alumnos
        /// </summary>
        public void cargaAlumnosPrimero()
        {
            Alumno alumnoPrimero1 = new Alumno(0, "David Abraham", "Aguilar Martín", 1);
            Alumno alumnoPrimero2 = new Alumno(1, "Carlos ", "Alberto Vadillo", 1);
            Alumno alumnoPrimero3 = new Alumno(2, "Manuel ", "Bancalero Carretero", 1);
            _listaAlumnos.Add(alumnoPrimero1);
            _listaAlumnos.Add(alumnoPrimero2);
            _listaAlumnos.Add(alumnoPrimero3);
        }

        /// <summary>
        /// Carga algunos alumnos de segundo en la lista Alumnos
        /// </summary>
        public void cargaAlumnosSegundo()
        {
            Alumno alumnoSegundo1 = new Alumno(0, "Francisco Javier", "Carmona Romero", 2);
            Alumno alumnoSegundo2 = new Alumno(1, "Iván ", "Castillo Calle", 2);
            Alumno alumnoSegundo3 = new Alumno(2, "Pablo ", "Chacón García", 2);
            _listaAlumnos.Add(alumnoSegundo1);
            _listaAlumnos.Add(alumnoSegundo2);
            _listaAlumnos.Add(alumnoSegundo3);
        }

        /// <summary>
        /// Carga algunos alumnos en la lista Alumnos
        /// </summary>
        public void cargaAlumnos()
        {
            Alumno alumnoPrimero1 = new Alumno(0, "David Abraham", "Aguilar Martín", 1);
            Alumno alumnoPrimero2 = new Alumno(1, "Carlos ", "Alberto Vadillo", 1);
            Alumno alumnoPrimero3 = new Alumno(2, "Manuel ", "Bancalero Carretero", 1);
            Alumno alumnoSegundo1 = new Alumno(3, "Francisco Javier", "Carmona Romero", 2);
            Alumno alumnoSegundo2 = new Alumno(4, "Iván ", "Castillo Calle", 2);
            Alumno alumnoSegundo3 = new Alumno(5, "Pablo ", "Chacón García", 2);

            _listaAlumnos.Add(alumnoPrimero1);
            _listaAlumnos.Add(alumnoPrimero2);
            _listaAlumnos.Add(alumnoPrimero3);
            _listaAlumnos.Add(alumnoSegundo1);
            _listaAlumnos.Add(alumnoSegundo2);
            _listaAlumnos.Add(alumnoSegundo3);
        }


    }
}
