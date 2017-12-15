using Capa_DAL.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Gestoras
{
    public class GestoraPersonasDAL
    {

        /// <summary>
        /// Dado un id de Persona realiza una consulta a la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la Persona</param>
        /// <returns>La persona devuelta será la persona asociada al id dado</returns>
        public Persona getPersona(int idPersona)
        {
            Persona persona = null;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterIdPersona = new SqlParameter();
            SqlDataReader dataReader;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono From Personas where ID=@idPersona";

                parameterIdPersona.ParameterName = "@idPersona";
                parameterIdPersona.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdPersona.Value = idPersona;

                sqlCommand.Parameters.Add(parameterIdPersona);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    persona = new Persona();
                    persona.id = (int)dataReader["ID"];
                    persona.nombre = (string)dataReader["Nombre"];
                    persona.apellidos = (string)dataReader["Apellidos"];
                    persona.fechaNac = (DateTime)dataReader["FechaNacimiento"];
                    if (System.DBNull.Value != dataReader["Direccion"])
                    {
                        persona.direccion = (string)dataReader["Direccion"];
                    }
                    if (System.DBNull.Value != dataReader["Direccion"])
                    {
                        persona.telefono = (string)dataReader["Telefono"];
                    }
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
        /// Recibe una persona y la inserta en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int insertPersona(Persona persona)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterNombre = new SqlParameter();
            SqlParameter parameterApellidos = new SqlParameter();
            SqlParameter parameterFechaNac = new SqlParameter();
            SqlParameter parameterDireccion = new SqlParameter();
            SqlParameter parameterTelefono = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "insert into Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono)" +
                                         " values(@nombre, @apellidos, @fechaNac, @direccion, @telefono)";

                parameterNombre.ParameterName = "@nombre";
                parameterNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterNombre.Value = persona.nombre;

                parameterApellidos.ParameterName = "@apellidos";
                parameterApellidos.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterApellidos.Value = persona.apellidos;

                parameterFechaNac.ParameterName = "@fechaNac";
                parameterFechaNac.SqlDbType = System.Data.SqlDbType.SmallDateTime;
                parameterFechaNac.Value = persona.fechaNac;

                parameterDireccion.ParameterName = "@direccion";
                parameterDireccion.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterDireccion.Value = persona.direccion;

                parameterTelefono.ParameterName = "@telefono";
                parameterTelefono.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterTelefono.Value = persona.telefono;

                sqlCommand.Parameters.Add(parameterNombre);
                sqlCommand.Parameters.Add(parameterApellidos);
                sqlCommand.Parameters.Add(parameterFechaNac);
                sqlCommand.Parameters.Add(parameterDireccion);
                sqlCommand.Parameters.Add(parameterTelefono);

                affectedRows=sqlCommand.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return affectedRows;
        }


        /// <summary>
        /// Dado un id de Persona elimina la persona asociada en la tabla Personas de la base de datos PersonasDB
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la persona</param>
        /// <returns>Un entero con las filas afectadas</returns>
        public int deletePersona(int idPersona)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterId = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Delete from Personas where ID=@idPersona";

                parameterId.ParameterName = "@idPersona";
                parameterId.SqlDbType = System.Data.SqlDbType.Int;
                parameterId.Value = idPersona;

                sqlCommand.Parameters.Add(parameterId);

                affectedRows = sqlCommand.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return affectedRows;
        }


        /// <summary>
        /// Dado un id de Persona y un Objeto Persona, actualiza la Persona asociada al id dado en la tabla Personas 
        /// con los datos del objeto Persona que llega por parametros
        /// </summary>
        /// <param name="idPersona">Un entero que es el id de la Persona</param>
        /// <param name="persona">Un objeto Persona cuyas propiedades se usarán para actualizar la Persona de la tabla Personas</param>
        /// <returns>Un entero con la cantidad de filas afectadas</returns>
        public int updatePersona(int idPersona, Persona persona)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter parameterNombre = new SqlParameter();
            SqlParameter parameterApellidos = new SqlParameter();
            SqlParameter parameterFechaNac = new SqlParameter();
            SqlParameter parameterDireccion = new SqlParameter();
            SqlParameter parameterTelefono = new SqlParameter();
            SqlParameter parameterIdPersona = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "update Personas set Nombre=@nombre, Apellidos=@apellidos, FechaNacimiento=@fechaNac, Direccion=@direccion, Telefono=@telefono where ID=@idPersona";

                parameterNombre.ParameterName = "@nombre";
                parameterNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterNombre.Value = persona.nombre;

                parameterApellidos.ParameterName = "@apellidos";
                parameterApellidos.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterApellidos.Value = persona.apellidos;

                parameterFechaNac.ParameterName = "@fechaNac";
                parameterFechaNac.SqlDbType = System.Data.SqlDbType.SmallDateTime;
                parameterFechaNac.Value = persona.fechaNac;

                parameterDireccion.ParameterName = "@direccion";
                parameterDireccion.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterDireccion.Value = persona.direccion;

                parameterTelefono.ParameterName = "@telefono";
                parameterTelefono.SqlDbType = System.Data.SqlDbType.VarChar;
                parameterTelefono.Value = persona.telefono;

                parameterIdPersona.ParameterName = "@idPersona";
                parameterIdPersona.SqlDbType = System.Data.SqlDbType.Int;
                parameterIdPersona.Value = idPersona;

                sqlCommand.Parameters.Add(parameterNombre);
                sqlCommand.Parameters.Add(parameterApellidos);
                sqlCommand.Parameters.Add(parameterFechaNac);
                sqlCommand.Parameters.Add(parameterDireccion);
                sqlCommand.Parameters.Add(parameterTelefono);
                sqlCommand.Parameters.Add(parameterIdPersona);

                affectedRows = sqlCommand.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return affectedRows;
        }



    }
}
