using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades Básicas:
    ID: Entero, consultable, modificable
    Nombre: Cadena, consultable, modificable
    Precio: Double, consultable, modificable
    IdCategoria: Entero, consultable, modificable
*/

namespace Entidades
{
    public class Producto
    {
        private int _id;
        private string _nombre;
        private Decimal _precio;
        private int _idCategoria;

        public Producto()
        {
            _id = 0;
            _nombre = "";
            _precio = 0;
            _idCategoria = 0;
        }

        public Producto(int id, string nombre, Decimal precio, int idCategoria)
        {
            _id = id;
            _nombre = nombre;
            _precio = precio;
            _idCategoria = idCategoria;
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

        public Decimal Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return _idCategoria;
            }
            set
            {
                _idCategoria = value;
            }
        }







    }
}
