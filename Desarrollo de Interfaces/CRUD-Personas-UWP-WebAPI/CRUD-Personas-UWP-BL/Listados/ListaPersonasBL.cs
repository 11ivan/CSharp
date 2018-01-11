using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_UWP_Entidades;
using CRUD_Personas_UWP_DAL.Listados;

/*
Ésta clase será la encargada de ofrecer a nuestra capa UI el listado de Personas dado por nuestra clase de la capa DAL (ListadoPersonasDAL) 
     
*/

namespace CRUD_Personas_UWP_BL.Listados
{
    public class ListaPersonasBL
    {


        /// <summary>
        /// Ofrece un listado de personas
        /// </summary>
        /// <returns>Devuelve un listado de personas</returns>
        public async Task<List<Persona>> getListaPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            ListadoPersonasDAL listadoPersonasDAL = new ListadoPersonasDAL();
            try
            {
                listaPersonas = await listadoPersonasDAL.getPersonas();
            }
            catch (Exception e)
            {
                throw e;
            }
            //Aquí realizariamos el filtrado indicado en la lógica de negocio
            return listaPersonas;
        }


    }
}
