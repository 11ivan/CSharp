using CapaDAL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Gestoras
{
    public class GestoraCategoriasPremiosBL
    {
        /// <summary>
        /// Devuelve un listado con las categorias de los premios de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPremio> getListaCategoriasPremios()
        {
            List<CategoriaPremio> listadoCategoriasPremios = new List<CategoriaPremio>();
            GestoraCategoriasPremiosDAL gestoraCategoriasPremiosDAL = new GestoraCategoriasPremiosDAL();

            try
            {
                listadoCategoriasPremios = gestoraCategoriasPremiosDAL.getListaCategoriasPremios();   
            }
            catch (Exception e)
            {
                throw e;
            }            
            return listadoCategoriasPremios;
        }
    }
}
