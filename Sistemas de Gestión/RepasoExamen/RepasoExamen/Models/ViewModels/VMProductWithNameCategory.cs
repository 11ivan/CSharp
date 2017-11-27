using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
   
    Propiedades Básicas:
        ID: Entero, consultable, modificable
        Nombre: Cadena, consultable, modificable
        Precio: Double, consultable, modificable
        Nombre Categoria: Cadena, Consultable, Modificable
*/

namespace RepasoExamen.Models.ViewModels
{
    public class VMProductWithNameCategory
    {
        private int _id;
        private string _nombre;
        private Decimal _precio;
        private string _nombreCategoria;


        public VMProductWithNameCategory()
        {
            _id = 0;
            _nombre = "";
            _precio = 0;
            _nombreCategoria = "";
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

        [Required(ErrorMessage="Campo Obligatorio")]
        [MaxLength(25, ErrorMessage = "Longitud máxima de 25 caracteres")]
        [MinLength(2, ErrorMessage = "Longitud mínima de 2 caracteres")]
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

        [Required(ErrorMessage = "Campo Obligatorio")]
        //[DataType(Decimal)]
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

        public string NombreCategoria
        {
            get
            {
                return _nombreCategoria;
            }
            set
            {
                _nombreCategoria = value;
            }
        }



    }
}