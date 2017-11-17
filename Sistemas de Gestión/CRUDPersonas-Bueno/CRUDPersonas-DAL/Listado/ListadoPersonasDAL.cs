using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Connection;

namespace CRUDPersonas_DAL.Listado
{
    public class ListadoPersonasDAL
    {

        /// <summary>
        /// Returns list with persons in the Data Base
        /// </summary>
        /// <returns></returns>
        public List<Persona> getPersonas()
        {
            Conexion conexion=new Conexion();
            List<Persona> listaPersonas = new List<Persona>();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            Persona persona;
            try
            {
                //conexion.connection.ConnectionString = conexion.getDataConnection();
                conexion.openConnection();
               // conexion.connection.Open();
                command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento FROM Personas";
                command.Connection = conexion.connection;
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        persona = new Persona();
                        persona.id = (int)dataReader["ID"];
                        persona.nombre = (string)dataReader["Nombre"];
                        persona.apellidos = (string)dataReader["Apellidos"];
                        persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                        listaPersonas.Add(persona);
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listaPersonas;
        }


    }
}
