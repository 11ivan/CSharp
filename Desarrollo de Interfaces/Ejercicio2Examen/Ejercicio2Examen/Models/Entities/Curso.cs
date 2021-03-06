﻿using _19_BindingListaPersonas.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades  Básicas:
    Nombre: Cadena, Consultable, Modificable
    IDCurso: Entero, Consultable, Modificable
*/

namespace Ejercicio2Examen.Models.Entities
{
    public class Curso:clsVMBase
    {

        private String _nombreCurso;
        private int _idCurso;

        public Curso()
        {
            _nombreCurso = "";
            _idCurso = 0;
        }

        public Curso(String nombreCurso, int idCurso)
        {
            _nombreCurso = nombreCurso;
            _idCurso = idCurso;
        }


        public String NombreCurso
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

        public int IdCurso
        {
            get
            {
                return _idCurso;
            }
            set
            {
                _idCurso = value;
                NotifyPropertyChanged("IdCurso");
            }
        }

            
    }
}
