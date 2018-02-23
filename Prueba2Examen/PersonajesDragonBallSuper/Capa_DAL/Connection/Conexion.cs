using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Connection
{
    public  class Conexion
    {
        private Uri server;


        public Conexion()
        {
            server = new Uri("http://localhost:60073/api/PersonajeConTransformacionesYHabilidades");
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
