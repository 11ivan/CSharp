using CapaDAL.Connection;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Gestoras
{
    public class GestoraCasasDAL
    {   
        /// <summary>
        /// Devuelve un listado con las casas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Casa> getListaCasas()
        {
            List<Casa> listadoCasas = new List<Casa>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Casa casa;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idCasa, nombreCasa From casas";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        casa = new Casa();
                        casa.ID = (int)dataReader["idCasa"];
                        casa.Nombre = (string)dataReader["nombreCasa"];
                        listadoCasas.Add(casa);
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
            return listadoCasas;
        }

        /// <summary>
        /// Dado un id devuelve la casa asociada al mismo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Casa getCasa(int id)
        {
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Casa casa = new Casa();
            SqlParameter parameterID = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idCasa, nombreCasa From casas where idCasa=@id";

                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();                 
                    casa.ID = (int)dataReader["idCasa"];
                    casa.Nombre = (string)dataReader["nombreCasa"];
                    
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
            return casa;
        }


    }
}
