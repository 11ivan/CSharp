﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConexionBaseDatos.Models
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNac;


        public Persona()
        {
            _id = 0;
            _nombre = "";
            _apellidos = "";
            _fechaNac = new DateTime();
        }


        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public string apellidos
        {
            get
            {
                return this._apellidos;
            }
            set
            {
                this._apellidos = value;
            }
        }

        public DateTime fechaNac
        {
            get
            {
                return this._fechaNac;
            }
            set
            {
                this._fechaNac = value;
            }

        }



    }
}