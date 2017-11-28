using Capa_BL.Gestoras;
using Capa_BL.Listados;
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
        idCategoria Categoria: Entero, Consultable, Modificable

    Propiedades Agregadas:
        Lista de Categorias: List<Categoria>, Consultable, Modificable
*/

namespace RepasoExamen.Models.ViewModels
{
    public class VMProductWithListCategories
    {

        private int _id;
        private string _nombre;
        private Decimal _precio;
        private int _idCategoria;
        private List<Categoria> _listaCategorias;

        public VMProductWithListCategories()
        {
            _id = 0;
            _nombre = "";
            _precio = 0;
            _idCategoria = 0;
            _listaCategorias = new List<Categoria>();
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

        [Required(ErrorMessage = "Campo Obligatorio")]
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

        public List<Categoria> ListaCategorias
        {
            get
            {
                return _listaCategorias;
            }
            set
            {
                _listaCategorias = value;
            }
        }

        /// <summary>
        /// Carga las categorias de la base de datos en _listadoCategorias
        /// </summary>
        public void cargaListaCategorias()
        {
            ListadoCategoriasBL listadoCategoriasBL = new ListadoCategoriasBL();
            try
            {
                _listaCategorias = listadoCategoriasBL.getListadoCategorias();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Primero carga en _listaCategorias la categoria que ya contiene el producto y después el resto que haya 
        /// en la base de datos
        /// </summary>
        public void cargaCategoriasPrimeroLaTuya()
        {
            ListadoCategoriasBL listadoCategoriasBL = new ListadoCategoriasBL();
            GestoraCategoriasBL gestoraCategoriasBL = new GestoraCategoriasBL();
            List<Categoria> listaCategoriasBaseDatos = listadoCategoriasBL.getListadoCategorias();

            _listaCategorias.Add(gestoraCategoriasBL.getCategoria(_idCategoria));

            for (int i=0;i<listaCategoriasBaseDatos.Count;i++)
            {
                if ( ! _listaCategorias.Contains(listaCategoriasBaseDatos.ElementAt(i)) )
                {
                    _listaCategorias.Add(listaCategoriasBaseDatos.ElementAt(i));
                }
            }
        }


        /*public Boolean exist(int idcategoria)
        {
            Boolean existe = false;

            for (int i=0;i<_listaCategorias.Count && !existe;i++)
            {
                if ()
                {

                }
            }

            return existe;
        }*/


    }
}