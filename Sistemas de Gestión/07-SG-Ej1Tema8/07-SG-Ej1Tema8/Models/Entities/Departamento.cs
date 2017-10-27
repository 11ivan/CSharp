using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_SG_Ej1Tema8.Models.Entities
{
    public class Departamento
    {
        private string nombre;
        private int id;


        public Departamento()
        {
            nombre = " ";
            id = 0;
        }

        public Departamento(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

    }
}