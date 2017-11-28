using Capa_BL.Gestoras;
using Capa_BL.Listados;
using Entidades;
using RepasoExamen.Models.Listados;
using RepasoExamen.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepasoExamen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ListadoProductosBL listadoProductosBL = new ListadoProductosBL();
            //List<Producto> listaProductos = new List<Producto>();
            ListadoVMProductWithNameCategory listadoVMProductWithNameCategory = new ListadoVMProductWithNameCategory();
            try
            {
                //listaProductos = listadoProductosBL.getListadoProductos();
                listadoVMProductWithNameCategory.cargaListado();
            }catch(Exception e)
            {
                throw e;
            }
            return View(listadoVMProductWithNameCategory.ListadoProductosConNombreCategoria);
        }


        public ActionResult Create()
        {
            VMProductWithListCategories vMProductWithListCategories = new VMProductWithListCategories();
            vMProductWithListCategories.cargaListaCategorias();
            return View(vMProductWithListCategories);
        }

        [HttpPost]
        public ActionResult Create(VMProductWithListCategories vmProductWithListCategories)
        {
            if (!ModelState.IsValid)
            {
                vmProductWithListCategories.cargaListaCategorias();
                return View(vmProductWithListCategories);
            }
            else
            {
                GestoraProductosBL gestoraProductoBL = new GestoraProductosBL();
                Producto producto = new Producto();
                producto.Nombre = vmProductWithListCategories.Nombre;
                producto.Precio = vmProductWithListCategories.Precio;
                producto.IdCategoria = vmProductWithListCategories.IdCategoria;
                //insertar producto en la base de datos
                gestoraProductoBL.insertProduct(producto);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            VMProductWithListCategories vmProductWithListCategories = new VMProductWithListCategories();
            GestoraProductosBL gestoraProductosBL = new GestoraProductosBL();
            try
            {
                Producto producto= new Producto();
                producto = gestoraProductosBL.getProducto(id);
                vmProductWithListCategories.ID = producto.ID;
                vmProductWithListCategories.Nombre = producto.Nombre;
                vmProductWithListCategories.Precio = producto.Precio;
                vmProductWithListCategories.IdCategoria = producto.IdCategoria;
                vmProductWithListCategories.cargaCategoriasPrimeroLaTuya();
            }catch(Exception e){
                throw e;
            }
            return View(vmProductWithListCategories);
        }


    }
}