using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PasarDatosView.Models
{
    public class Persona{
        private String nombre;
       // private String apellido;


        public Persona() {
            nombre = "";
        }

        public String getNombre() {
            return nombre;
        }

        public void setNombre(String nombre) {
            this.nombre = nombre;
        }
    }
}