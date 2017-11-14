using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ConexionBaseDatos.Models
{
    public class Conexion
    {
        String pass = "$estamisma0770$";







































        public SqlConnection connection { get; }


        public Conexion()
        {
            connection = new SqlConnection();
        }

        public Boolean openConnection() {
            Boolean ok = true;

            try
            {
                connection.ConnectionString=("server=miserverpersonas.database.windows.net; database=PersonasDB; uid=icastillo; pwd="+ pass);
                connection.Open();
            }catch(SqlException e){
                ok = false;
            }
            return ok;
        }

    }
}