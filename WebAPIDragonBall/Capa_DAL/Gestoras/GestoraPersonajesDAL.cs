using Capa_DAL.Connection;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraPersonajesDAL
    {

        public List<Personaje> getListaPersonajes()
        {
            List<Personaje> listadoPersonajes = new List<Personaje>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Personaje personaje;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre From Personajes";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        personaje = new Personaje();
                        personaje.ID = (int)dataReader["ID"];
                        personaje.Nombre = (string)dataReader["Nombre"];
                        listadoPersonajes.Add(personaje);
                    }
                }
                dataReader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.connection.Close();
            }
            return listadoPersonajes;
        }


        public Personaje getPersonaje(int id)
        {
            Personaje personaje = new Personaje();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterID = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre From Personajes where ID=@id";

                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();                    
                   
                    personaje.ID = (int)dataReader["ID"];
                    personaje.Nombre = (string)dataReader["Nombre"];
                    
                }
                dataReader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conexion.connection.Close();
            }
            return personaje;
        }





    }
}
