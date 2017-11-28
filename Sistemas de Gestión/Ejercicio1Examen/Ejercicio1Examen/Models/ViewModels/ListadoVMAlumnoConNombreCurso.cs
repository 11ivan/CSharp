using Capa_BL.Gestoras;
using Capa_BL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
Propiedades:
    Listado de VMAlumnoConNombreCurso: List<VMAlumnoConNombreCurso>, consultable, modificable
*/

namespace Ejercicio1Examen.Models.ViewModels
{
    public class ListadoVMAlumnoConNombreCurso
    {
        private List<VMAlumnoConNombreCurso> _listadoVMAlumnoConNombreCurso;

        public ListadoVMAlumnoConNombreCurso()
        {
            _listadoVMAlumnoConNombreCurso = new List<VMAlumnoConNombreCurso>();
        }


        /// <summary>
        /// Carga _listadoVMAlumnoConNombreCurso con los alumnos asociados al nombre del curso recibido
        /// en la base de datos
        /// </summary>
        public void cargaListadoAlumnosConNombreCurso(int idCurso)
        {
            ListadoAlumnosBL listadoAlumnosBL = new ListadoAlumnosBL();
            List<Alumno> listaAlumnos = new List<Alumno>();
            GestoraCursosBL gestoraCursosBL = new GestoraCursosBL();
            try
            {
                string nombreCurso = gestoraCursosBL.getCurso(idCurso).Nombre;
                listaAlumnos = listadoAlumnosBL.getListadoAlumnosCurso(nombreCurso);
                for (int i=0;i<listaAlumnos.Count;i++)
                {
                    VMAlumnoConNombreCurso vMAlumnoConNombreCurso = new VMAlumnoConNombreCurso();
                    vMAlumnoConNombreCurso.ID = listaAlumnos.ElementAt(i).ID;
                    vMAlumnoConNombreCurso.Nombre = listaAlumnos.ElementAt(i).Nombre;
                    vMAlumnoConNombreCurso.IdCurso = listaAlumnos.ElementAt(i).IdCurso;
                    vMAlumnoConNombreCurso.Beca = listaAlumnos.ElementAt(i).Beca;
                    vMAlumnoConNombreCurso.NombreCurso = gestoraCursosBL.getCurso(idCurso).Nombre;
                    _listadoVMAlumnoConNombreCurso.Add(vMAlumnoConNombreCurso);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}