using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades Básicas:
    ID: Entero, consultable, modificable
    Nombre: Cadena, consultable, modificable
*/


namespace Entidades
{
    public class Categoria
    {
        private int _id;
        private string _nombre;

        public Categoria()
        {
            _id = 0;
            _nombre = "";
        }

        public Categoria(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }


        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

    }
}
