﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CRUD_Personas_UWP_Entidades;
using CRUD_Personas_UWP_DAL.Connection;
using Windows.Web.Http;

/*
Ésta clase se encargará de ofrecer un listado con las Personas de nuestra base de datos
     
     
*/


namespace CRUD_Personas_UWP_DAL.Listados
{
    public class ListadoPersonasDAL
    {

        /// <summary>
        /// Returns list with persons in the Data Base
        /// </summary>
        /// <returns></returns>
        public async Task<List<Persona>> getPersonas()
        {
            Conexion conexion=new Conexion();
            List<Persona> listaPersonas = new List<Persona>();
            HttpClient httpClient = new HttpClient();

            string listadoJson = await httpClient.GetStringAsync(conexion.Server);
            httpClient.Dispose();
            listaPersonas = JsonConvert.DeserializableObject(listadoJson);

            return listaPersonas;
        }

    }
}
