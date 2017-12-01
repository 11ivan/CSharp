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
        public Persona getPersona(int id)
        {
            //Boolean sal = false;
            Persona persona = new Persona();
            Conexion conexion = new Conexion();
            //List<Persona> listaPersonas = new List<Persona>();
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameter;

            try
            {
                conexion.openConnection();
                //command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento FROM Personas where ID="+id;
                command.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento FROM Personas where ID= @id";
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                command.Parameters.Add(parameter);
                command.Connection = conexion.connection;
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    //while (dataReader.Read())
                    //{        
                    dataReader.Read();
                    persona.id = (int)dataReader["ID"];
                    persona.nombre = (string)dataReader["Nombre"];
                    persona.apellidos = (string)dataReader["Apellidos"];
                    persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                    //listaPersonas.Add(persona);
                    //}
                }
                dataReader.Close();
                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return persona;
        }

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
            command.CommandText = "Update Personas set nombre=@nombre, apellidos=@apellido, FechaNacimiento=@fechaNac WHERE ID=@id";
            SqlParameter paramID = new SqlParameter();
            SqlParameter paramNombre = new SqlParameter(); 
            SqlParameter paramApellido=new SqlParameter();            
            SqlParameter paramFechaNac=new SqlParameter();

            try
            {
                conexion.openConnection();
                paramID.ParameterName = "@id";
                paramID.SqlDbType = System.Data.SqlDbType.Int;
                paramID.Value = persona.id;

                paramNombre.ParameterName = "@nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramNombre.Value = persona.nombre;

                paramApellido.ParameterName = "@apellido";
                paramApellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramApellido.Value = persona.apellidos;

                paramFechaNac.ParameterName = "@fechaNac";
                paramFechaNac.SqlDbType = System.Data.SqlDbType.DateTime;
                paramFechaNac.Value = persona.fechaNac;

                command.Parameters.Add(paramID);
                command.Parameters.Add(paramNombre);
                command.Parameters.Add(paramApellido);
                command.Parameters.Add(paramFechaNac);

                command.Connection = conexion.connection;

                affectedRows = command.ExecuteNonQuery();
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

                paramID.ParameterName = "@id";
                paramID.SqlDbType = System.Data.SqlDbType.Int;
                paramID.SqlValue = id;
                command.Parameters.Add(paramID);

                command.Connection = conexion.connection;
                affectedRows= command.ExecuteNonQuery();
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
            command.CommandText = "INSERT INTO Personas values(@nombre, @apellidos, @fechaNac)";
            SqlParameter paramNombre = new SqlParameter();
            SqlParameter paramApellido = new SqlParameter();
            SqlParameter paramFechaNac = new SqlParameter();
            try
            {
                conexion.openConnection();

                paramNombre.ParameterName = "@nombre";
                paramNombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramNombre.SqlValue = persona.nombre;

                paramApellido.ParameterName = "@apellidos";
                paramApellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                paramApellido.SqlValue = persona.apellidos;

                paramFechaNac.ParameterName = "@fechaNac";
                paramFechaNac.SqlDbType = System.Data.SqlDbType.DateTime;
                paramFechaNac.SqlValue = persona.fechaNac;

                command.Parameters.Add(paramNombre);
                command.Parameters.Add(paramApellido);
                command.Parameters.Add(paramFechaNac);

                command.Connection = conexion.connection;
                affectedRows= command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return affectedRows;
        }



    }
}
