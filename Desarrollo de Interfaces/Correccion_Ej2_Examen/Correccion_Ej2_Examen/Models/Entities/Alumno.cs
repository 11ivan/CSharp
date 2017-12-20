using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades Básicas:
    IDAlumno: Entero, Consultable, Modificable
    Nombre: Cadena, Consultable, Modificable
    Apellidos: Cadena, Consultable, Modificable
    ID Curso: Entero, Consultable, Modificable
*/


namespace Correccion_Ej2_Examen.Models.Entities
{
    public class Alumno
    {
        private int _idAlumno;
        private String _nombreAlumno;
        private String _apellidosAluno;
        private int _idCurso;


        public Alumno()
        {
            _idAlumno = 0;
            _nombreAlumno = "";
            _apellidosAluno = "";
            _idCurso = 0;
        }

        public Alumno(int idAlumno, String nombreAlumno, String apellidosAlumno, int idCurso)
        {
            _idAlumno = idAlumno;
            _nombreAlumno = nombreAlumno;
            _apellidosAluno = apellidosAlumno;
            _idCurso = idCurso;
        }

        public int IdAlumno
        {
            get
            {
                return _idAlumno;
            }
            set
            {
                _idAlumno = value;
            }
        }

        public String NombreAlumno
        {
            get
            {
                return _nombreAlumno;
            }
            set
            {
                _nombreAlumno = value;
            }
        }


        public String ApellidosAlumno
        {
            get
            {
                return _apellidosAluno;
            }
            set
            {
                _apellidosAluno = value;
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











    }
}
