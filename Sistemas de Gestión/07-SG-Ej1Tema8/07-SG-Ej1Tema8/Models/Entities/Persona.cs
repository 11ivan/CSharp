using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_SG_Ej1Tema8.Models
{
    public class Persona{
        private String nombre;
        private String apellido;
        private int idDepartamento;

        public Persona() {
            nombre = "Ivan";
            apellido = "Castillo";
            idDepartamento = 0;
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

        public int IdDepartamento
        {
            get
            {
                return idDepartamento;
            }
            set
            {
                idDepartamento = value;
            }

        }

    }
}