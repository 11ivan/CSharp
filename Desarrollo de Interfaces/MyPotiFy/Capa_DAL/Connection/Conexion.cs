using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Connection
{
    public class Conexion
    {

        private Uri server;


        public Conexion()
        {
            //server = new Uri("http://apipersonasdb.azurewebsites.net/api/Personas");
            server = new Uri("http://apipersonasdb.azurewebsites.net/api/Personas");
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
