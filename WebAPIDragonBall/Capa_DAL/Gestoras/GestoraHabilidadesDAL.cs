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
    public class GestoraHabilidadesDAL
    {
        public List<Habilidad> getListaHabilidades()
        {
            List<Habilidad> listadoHabilidades = new List<Habilidad>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Habilidad habilidad;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, Poder, ID_Personaje From Habilidades";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        habilidad = new Habilidad();
                        habilidad.ID = (int)dataReader["ID"];
                        habilidad.Nombre = (string)dataReader["Nombre"];
                        habilidad.IdPersonaje = (int)dataReader["ID_Personaje"];
                        habilidad.Poder = (int)dataReader["Poder"];                      

                        listadoHabilidades.Add(habilidad);
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
            return listadoHabilidades;
        }


        public Habilidad getHabilidad(int id)
        {
            Habilidad habilidad = new Habilidad();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterID = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre, RutaImagen, ID_Personaje From Habilidades where ID=@id";

                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    habilidad.ID = (int)dataReader["ID"];
                    habilidad.Nombre = (string)dataReader["Nombre"];
                    habilidad.Poder = (int)dataReader["Poder"];
                    habilidad.IdPersonaje = (int)dataReader["ID_Personaje"];
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
            return habilidad;
        }

    }
}
