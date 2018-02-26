using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Connection
{
    public class Conexion
    {
        private String server = "server=localhost";
        private String dataBase = "database=DragonBallSuper2";
        private String uid = "uid=prueba";
        private String pass = "pwd=1234";

        public SqlConnection connection { get; }


        public Conexion()
        {
            connection = new SqlConnection();
        }


        /// <summary>
        /// Returns the data necessary for the connection to the database
        /// </summary>
        /// <returns></returns>
        public String getDataConnection()
        {
            String datosConexion = server + ";" + dataBase + ";" + uid + ";" + pass;
            return datosConexion;
        }

        /// <summary>
        /// Open connection with data base
        /// </summary>
        /// <returns>Boolean, true if open the connection correctly else false</returns>
        public Boolean openConnection()
        {
            Boolean ok = true;

            try
            {
                connection.ConnectionString = getDataConnection();
                connection.Open();
            }
            catch (SqlException e)
            {
                ok = false;
            }
            return ok;
        }


        /// <summary>
        /// Return state of Object SqlConnection
        /// </summary>
        /// <returns>String with value "Open" if connection is open, "Closed" if connection is closed </returns>
        public String getState()
        {
            String state = this.connection.State.ToString();
            return state;
        }



    }
}
