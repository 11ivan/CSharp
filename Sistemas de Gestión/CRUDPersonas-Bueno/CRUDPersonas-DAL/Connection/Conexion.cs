using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CRUDPersonas_Entidades;

namespace CRUDPersonas_DAL.Connection
{
    public class Conexion
    {
        private String server = "server=miserverpersonas.database.windows.net";
        private String dataBase = "database=PersonasDB";
        private String uid = "uid=icastillo";
        private String pass = "pwd=Dubu4589";

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
        public Boolean openConnection() {
            Boolean ok = true;

            try
            {
                connection.ConnectionString=getDataConnection();
                connection.Open();
            }catch(SqlException e){
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonas()
        {
            List <Persona> listaPersonas= new List<Persona>();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            Persona persona;
            try
            {
                connection.ConnectionString = getDataConnection();
                connection.Open();
                command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento FROM Personas";
                command.Connection = connection;
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        persona = new Persona();
                        persona.id =(int) dataReader["ID"];
                        persona.nombre = (string)dataReader["Nombre"];
                        persona.apellidos = (string)dataReader["Apellidos"];
                        persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                        listaPersonas.Add(persona);
                    }               
                }
                dataReader.Close();
                connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listaPersonas;
        }

    }
}