using Capa_DAL.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Listados
{
    public class ListadoPersonasDAL
    {


        /// <summary>
        /// Ofrece un listado con las personas que hay en la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <returns>List<Persona></returns>
        public List<Persona> getListadoPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Persona persona = null;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono From Personas";

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        persona = new Persona();
                        persona.id = (int)dataReader["ID"];
                        persona.nombre = (string)dataReader["Nombre"];
                        persona.apellidos = (string)dataReader["Apellidos"];
                        persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                        if (System.DBNull.Value!= dataReader["Direccion"])
                        {
                            persona.direccion = (string)dataReader["Direccion"];
                        }                       
                        if (System.DBNull.Value != dataReader["Direccion"])
                        {
                            persona.telefono = (string)dataReader["Telefono"];
                        }                       
                        listadoPersonas.Add(persona);
                    }
                }
                dataReader.Close();
                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return listadoPersonas;
        }

    }
}
