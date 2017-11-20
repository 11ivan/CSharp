﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using _19_BindingListaPersonas.Models.ViewModel;


namespace _19_BindingListaPersonas.Models
{
    public class Persona: clsVMBase
    {

        //private int _id;
        private static int _id=0;
        //public int idDepartamento { get; set; }
        private String _nombre;
        private String _apellido;
        private DateTime _fechaNac;
        private String _direccion;
        private String _telefono;

        //public event PropertyChangedEventHandler PropertyChanged;

        public Persona()
        {
            _id++;
            //idDepartamento = 0;
            //_nombre = "";
            //_apellido = "";
            //_fechaNac = new DateTime();
            //_direccion = "";
            //_telefono = "";
        }

        public Persona(String nombre, String apellido, String direccion, String telefono):this()
        {
            
            //this.idDepartamento = idDepartamento;
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNac = fechaNac;
            this._direccion = direccion;
            this._telefono = telefono;
        }

        /*public Persona(int id, String nombre, String apellido, String direccion, String telefono)
        {
            this._id = id;
            //this.idDepartamento = idDepartamento;
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNac = fechaNac;
            this._direccion = direccion;
            this._telefono = telefono;
        }*/

        public Persona(Persona persona)
        {
            //this._id = persona.id;
            //this.idDepartamento = idDepartamento;
            this._nombre = persona.nombre;
            this._apellido = persona.apellido;
            this._fechaNac = fechaNac;
            this._direccion = persona.direccion;
            this._telefono = persona.telefono;
        }


        public int id
        {
            get{
                return _id;
            }
            /*set{
                this._id=value;
            }*/
        }

        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                this._nombre = value;
                
                NotifyPropertyChanged("nombre");
            }
        }

        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                this._apellido = value;
                NotifyPropertyChanged("apellido");
            }
        }

        public DateTime fechaNac
        {
            get
            {
                return _fechaNac;
            }
            set
            {
                this._fechaNac = value;
                //NotifyPropertyChanged();
            }
        }

        public String direccion
        {
            get
            {
                return _direccion;
            }
            set
            {           
                this._direccion = value;
                NotifyPropertyChanged("direccion");
            }
        }

        public String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                this._telefono = value;
                NotifyPropertyChanged("telefono");
            }
        }


       /* private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/



    }
}