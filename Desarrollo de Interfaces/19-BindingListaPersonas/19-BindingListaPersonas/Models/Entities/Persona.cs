using System;
using System.Collections.Generic;
using System.Linq;


namespace _19_BindingListaPersonas.Models
{
    public class Persona{

        public int id { get; set; }   
        //public int idDepartamento { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public DateTime fechaNac { get; set; }       
        public String direccion { get; set; }
        public String telefono { get; set; }


        public Persona()
        {
            id = 0;
            //idDepartamento = 0;
            nombre = "Iván";
            apellido = "Castillo";
            fechaNac = new DateTime(1990, 10, 2);
            direccion = "C/ S/N";
            telefono = "955111111";
        }

        public Persona(int id, String nombre, String apellido, String direccion, String telefono)
        {
            this.id = id;
            //this.idDepartamento = idDepartamento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public Persona(Persona persona)
        {
            this.id = persona.id;
            //this.idDepartamento = idDepartamento;
            this.nombre = persona.nombre;
            this.apellido = persona.apellido;
             this.fechaNac = fechaNac;
            this.direccion = persona.direccion;
            this.telefono = persona.telefono;
        }

    }
}