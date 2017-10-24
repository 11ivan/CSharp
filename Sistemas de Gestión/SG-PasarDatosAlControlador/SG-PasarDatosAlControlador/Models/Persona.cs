using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_PasarDatosAlControlador.Models
{
    public class Persona{
        private String nombre;
        private String apellido;


        public Persona() {
            nombre = "";
            apellido = "";
        }

        public String Nombre {
            get{
               return nombre;
            }
            set {
                nombre = value;
            }
        }


        public String Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }

        }

    }
}