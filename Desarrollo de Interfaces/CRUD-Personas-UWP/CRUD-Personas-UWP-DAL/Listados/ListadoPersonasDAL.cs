using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CRUD_Personas_UWP_Entidades;
using CRUD_Personas_UWP_DAL.Connection;

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
                command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono FROM Personas";
                command.Connection = conexion.connection;
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        persona = new Persona();
                        persona.id = (int)dataReader["ID"];
                        persona.nombre = (string)dataReader["Nombre"];
                        persona.apellido = (string)dataReader["Apellidos"];
                        persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                        persona.direccion = (string)dataReader["Direccion"];
                        persona.telefono = (string)dataReader["Telefono"];
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
