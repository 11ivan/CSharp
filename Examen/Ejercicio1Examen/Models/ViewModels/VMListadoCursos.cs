using Capa_BL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 *                             /// EL NOMBRE DE LA CLASE DEBERÍA SER VMListadoCursosConCurso ///
    Propiedades 
        Lista de Cursos: List<Curso>, consultable, modificable
        Curso: Curso, Consultable, Modificable
*/

namespace Ejercicio1Examen.Models
{
    public class VMListadoCursos:Curso
    {

        private List<Curso> _listadoCursos;
        //private Curso _curso;

        public VMListadoCursos():base()
        {
            _listadoCursos = new List<Curso>();
        }


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


        /// <summary>
        /// Carga _listadoCursos con los cursos disponibles en la base de datos
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

        }



    }
}