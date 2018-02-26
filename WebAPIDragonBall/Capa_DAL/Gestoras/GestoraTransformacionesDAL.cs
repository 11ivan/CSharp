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
    public class GestoraTransformacionesDAL
    {
        public List<Transformacion> getListaTransformaciones()
        {
            List<Transformacion> listadoTransformaciones = new List<Transformacion>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Transformacion transformacion;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, RutaImagen, ID_Personaje From Transformaciones";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        transformacion = new Transformacion();
                        transformacion.ID = (int)dataReader["ID"];
                        transformacion.Nombre = (string)dataReader["Nombre"];
                        transformacion.RutaImagen = (string)dataReader["RutaImagen"];
                        transformacion.IdPersonaje = (int)dataReader["ID_Personaje"];
                        listadoTransformaciones.Add(transformacion);
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
            return listadoTransformaciones;
        }


        public Transformacion getTransformacion(int id)
        {
            Transformacion transformacion = new Transformacion();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterID = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, RutaImagen, ID_Personaje From Transformaciones where ID=@id";

                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    transformacion.ID = (int)dataReader["ID"];
                    transformacion.Nombre = (string)dataReader["Nombre"];
                    transformacion.RutaImagen = (string)dataReader["RutaImagen"];
                    transformacion.IdPersonaje = (int)dataReader["ID_Personaje"];
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
            return transformacion;
        }

    }
}
