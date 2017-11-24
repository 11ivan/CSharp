using Ejercicio2Examen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades:
    Lista de alumnos: ObservableCollection<Curso>, consultable, modificable
*/

namespace Ejercicio2Examen.Models.Lists
{
    public class ListaCursos
    {
        private ObservableCollection<Curso> _listadoCursos;

        public ListaCursos()
        {
            _listadoCursos = new ObservableCollection<Curso>();
        }



        public ObservableCollection<Curso> ListadoCursos
        {
            get
            {
                return _listadoCursos;
            }
        }

        /// <summary>
        /// Carga algunos cursos en la lista de cursos
        /// </summary>
        public void cargaCursos()
        {
            Curso curso1 = new Curso("1º CFGS DAM", 1);
            Curso curso2 = new Curso("2º CFGS DAM", 2);
            _listadoCursos.Add(curso1);
            _listadoCursos.Add(curso2);
        }

    }
}
