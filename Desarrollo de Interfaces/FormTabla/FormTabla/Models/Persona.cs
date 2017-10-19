using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _FormTabla.Models
{
    public class Persona
    {
        private int id;
        private String nombre;
        private String apellidos;
        private DateTime fechaNac;
        private String direccion;
        private String telefono;


        public Persona()
        {
            id = 0;
            nombre = "Lola";
            apellidos = "La que va sola por Barcelona";
            fechaNac = new DateTime();
            direccion = "La Calle";
            telefono = "123456789";
        }

        public Persona(int id, String nombre, String apellidos, DateTime fechaNac, String direccion, String telefono) {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac.Date;
            this.direccion = direccion;
            this.telefono = telefono;
        }



        //Getters
        public int ID {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    nombre = value;
                }
            }
        }


        public String Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    apellidos = value;
                }
            }
        }


        /* public int getID() {
             return id;
         }
         public String getNombre()
         {
             return nombre;
         }

         public String getApellidos() {
             return apellidos;
         }

         public DateTime getFechaNac() {
             return fechaNac;
         }

         public String getDireccion() {
             return direccion;
         }

         public String getTelefono() {
             return telefono;
         }*/



        //Setters
        /* public void setID(int id) {
             this.id = id;
         }

         public void setNombre(String nombre)
         {
             if (!String.IsNullOrWhiteSpace(nombre)) {
                 this.nombre = nombre;
             }
         }

         public void setApellidos(String apellidos) {
             if (!String.IsNullOrWhiteSpace(apellidos))
             {
                 this.apellidos = apellidos;
             }
         }

         public void setFechaNac(DateTime fechaNac)
         {
             if (DateTime.Now>=fechaNac) {
                 this.fechaNac = fechaNac.Date;
             }
         }

         public void setDireccion(String direccion)
         {
             if (!String.IsNullOrWhiteSpace(direccion))
             {
                 this.direccion = direccion;
             }
         }

         public void setTelefono(String telefono)
         {
             string sPattern = "^\\d{9}$";
             if (!String.IsNullOrWhiteSpace(telefono) && telefono.Length==9 && Regex.IsMatch(telefono, sPattern)) {
                 this.telefono = telefono;
             }
         }*/



    }
}