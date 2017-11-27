using Capa_DAL.Gestoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Gestoras
{
    public class GestoraCategoriasBL
    {


        public Categoria getCategoria(int id)
        {
            Categoria categoria;
            GestoraCategoriasDAL gestoraCategoriasDAL = new GestoraCategoriasDAL();
            categoria = gestoraCategoriasDAL.getCategoria(id);
            return categoria;
        }



    }
}
