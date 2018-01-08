using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
//using CRUDPersonas_Entidades;

namespace CRUD_Personas_UWP_DAL.Connection
{
    public class Conexion
    {
        private Uri server;


        public Conexion()
        {
            server = new Uri("http://apipersonasdb.azurewebsites.net/api/Personas");//https://apipersonasdb.azurewebsites.net
        }

        public Uri Server
        {
            get
            {
                return server;
            }
        }

    }
}