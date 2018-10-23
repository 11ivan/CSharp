using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnnotation.Models.Entities
{
    public class Persona
    {

        public int id { get; set; }

        public String nombre { get; set; }

        public String apellido { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; }

        public int idDepartamento { get; set; }

        //Constructors
        public Persona()
        {
            nombre = "";
            apellido = "";
        }



    }
}
