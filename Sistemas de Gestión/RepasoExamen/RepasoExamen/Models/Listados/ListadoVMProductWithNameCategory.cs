using Capa_BL.Gestoras;
using Capa_BL.Listados;
using Entidades;
using RepasoExamen.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepasoExamen.Models.Listados
{
    public class ListadoVMProductWithNameCategory
    {
        private List<VMProductWithNameCategory> _listadoProductosConNombreCategoria;

        public ListadoVMProductWithNameCategory()
        {
            _listadoProductosConNombreCategoria = new List<VMProductWithNameCategory>();
        }


        public List<VMProductWithNameCategory> ListadoProductosConNombreCategoria
        {
            get
            {
                return _listadoProductosConNombreCategoria;
            }
            set
            {
                _listadoProductosConNombreCategoria = value;
            }
        }

        public void cargaListado()
        {
            ListadoProductosBL listadoProductosBL = new ListadoProductosBL();
            List<Producto> listaProductos = listadoProductosBL.getListadoProductos();
            GestoraCategoriasBL gestoraCategoriasBL = new GestoraCategoriasBL();
            for (int i=0;i<listaProductos.Count;i++)
            {
                VMProductWithNameCategory productWithNameCategory = new VMProductWithNameCategory();
                productWithNameCategory.ID = listaProductos.ElementAt(i).ID;
                productWithNameCategory.Nombre = listaProductos.ElementAt(i).Nombre;
                productWithNameCategory.Precio = listaProductos.ElementAt(i).Precio;
                //productWithNameCategory.IdCategoria = listaProductos.ElementAt(i).IdCategoria;
                productWithNameCategory.NombreCategoria = gestoraCategoriasBL.getCategoria(listaProductos.ElementAt(i).IdCategoria).Nombre;
                _listadoProductosConNombreCategoria.Add(productWithNameCategory);
            }
        }


    }
}