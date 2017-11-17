using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Listado;

namespace CRUDPersonas_BL.Listados
{
    public class ListaPersonasBL
    {


        public List<Persona> getListaPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            ListadoPersonasDAL listadoPersonasDAL = new ListadoPersonasDAL();
            listaPersonas = listadoPersonasDAL.getPersonas();
            //Aquí realizariamos el filtrado indicado en la lógica de negocio
            return listaPersonas;
        }



    }
}
