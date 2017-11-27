using Capa_DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoCategoriasBL
    {

        public List<Categoria> getListadoCategorias()
        {
            List<Categoria> listadoCategorias = new List<Categoria>();
            ListadoCategoriasDAL listadoCategoriasDAL = new ListadoCategoriasDAL();
            listadoCategorias = listadoCategoriasDAL.getListadoCategorias();
            return listadoCategorias;
        }


    }
}
