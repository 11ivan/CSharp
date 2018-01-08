using CRUD_Personas_UWP_DAL.Connection;
using CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ésta clase se encargará de realizar en CRUD en nuestra base de datos

 
*/


namespace CRUD_Personas_UWP_DAL.Gestoras
{
    public class GestoraPersonasDAL
    {

        /// <summary>
        /// Recibe el id de una persona y hace una consulta a la tabla Personas con ese id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve la persona con ese id</returns>
        /*public Persona getPersona(int id)
        {
            //Boolean sal = false;
            Persona persona = new Persona();
            Conexion conexion = new Conexion();
            //List<Persona> listaPersonas = new List<Persona>();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameter = new SqlParameter();

            try
            {
                conexion.openConnection();
                command.Connection = conexion.connection;
                command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono FROM Personas where ID= @id";
   
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;

                command.Parameters.Add(parameter);              
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {        
                    dataReader.Read();
                    persona.id = (int)dataReader["ID"];
                    persona.nombre = (string)dataReader["Nombre"];
                    persona.apellido = (string)dataReader["Apellidos"];
                    persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                    persona.direccion = (string)dataReader["Direccion"];
                    persona.telefono = (string)dataReader["Telefono"];
                }
                dataReader.Close();
                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return persona;
        }*/

        /// <summary>
        /// Actualiza una persona de la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Devuelve un entero con el número de filas afectadas</returns>
        public int updatePersona(Persona persona)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Update Personas set nombre=@nombre, apellidos=@apellido, FechaNacimiento=@fechaNac, Direccion=@direccion, Telefono=@telefono WHERE ID=@id";
            SqlParameter paramID = new SqlParameter();
            SqlParameter paramNombre = new SqlParameter(); 
            SqlParameter paramApellido=new SqlParameter();            
            SqlParameter paramFechaNac=new SqlParameter();
            SqlParameter paramDireccion = new SqlParameter();
            SqlParameter paramTelefono = new SqlParameter();

            try
            {
                conexion.openConnection();
                command.Connection = conexion.connection;

                paramID.ParameterName = "@id";
                paramID.SqlDbType = System.Data.SqlDbType.Int;
                paramID.Value = persona.id;

                paramNombre.ParameterName = "@nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramNombre.Value = persona.nombre;

                paramApellido.ParameterName = "@apellido";
                paramApellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramApellido.Value = persona.apellido;

                paramFechaNac.ParameterName = "@fechaNac";
                paramFechaNac.SqlDbType = System.Data.SqlDbType.DateTime;
                paramFechaNac.Value = persona.fechaNac;

                paramDireccion.ParameterName = "@direccion";
                paramDireccion.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramDireccion.Value = persona.direccion;

                paramTelefono.ParameterName = "@telefono";
                paramTelefono.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramTelefono.Value = persona.telefono;

                command.Parameters.Add(paramID);
                command.Parameters.Add(paramNombre);
                command.Parameters.Add(paramApellido);
                command.Parameters.Add(paramFechaNac);
                command.Parameters.Add(paramDireccion);
                command.Parameters.Add(paramTelefono);              

                affectedRows = command.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return affectedRows;
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un entero con el número de filas afectadas</returns>
        public int deletePersona(int id)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM Personas WHERE id=@id";
            SqlParameter paramID = new SqlParameter();

            try
            {
                conexion.openConnection();
                command.Connection = conexion.connection;

                paramID.ParameterName = "@id";
                paramID.SqlDbType = System.Data.SqlDbType.Int;
                paramID.SqlValue = id;
                command.Parameters.Add(paramID);
                
                affectedRows= command.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return affectedRows;
        }

        /// <summary>
        /// Inserta una persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Devuelve un entero que es el número de filas afectadas</returns>
        public int insertPersona(Persona persona)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO Personas values(@nombre, @apellidos, @fechaNac, @direccion, @telefono)";
            SqlParameter paramNombre = new SqlParameter();
            SqlParameter paramApellido = new SqlParameter();
            SqlParameter paramFechaNac = new SqlParameter();
            SqlParameter paramDireccion = new SqlParameter();
            SqlParameter paramTelefono = new SqlParameter();

            try
            {
                conexion.openConnection();
                command.Connection = conexion.connection;

                paramNombre.ParameterName = "@nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramNombre.SqlValue = persona.nombre;

                paramApellido.ParameterName = "@apellidos";
                paramApellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramApellido.SqlValue = persona.apellido;

                paramFechaNac.ParameterName = "@fechaNac";
                paramFechaNac.SqlDbType = System.Data.SqlDbType.DateTime;
                paramFechaNac.SqlValue = persona.fechaNac;

                paramDireccion.ParameterName = "@direccion";
                paramDireccion.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramDireccion.Value = persona.direccion;

                paramTelefono.ParameterName = "@telefono";
                paramTelefono.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramTelefono.Value = persona.telefono;

                command.Parameters.Add(paramNombre);
                command.Parameters.Add(paramApellido);
                command.Parameters.Add(paramFechaNac);
                command.Parameters.Add(paramDireccion);
                command.Parameters.Add(paramTelefono);
                
                affectedRows= command.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return affectedRows;
        }
        */


    }
}
