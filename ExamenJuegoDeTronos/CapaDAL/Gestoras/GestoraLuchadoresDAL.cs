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
    public class GestoraLuchadoresDAL
    {
        /// <summary>
        /// Devuelve un listado con los luchadores de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Luchador> getListaLuchadores()
        {
            List<Luchador> listadoLuchadores = new List<Luchador>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Luchador luchador;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idLuchador, nombreLuchador, idCasa From luchadores";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        luchador = new Luchador();
                        luchador.ID = (int)dataReader["idLuchador"];
                        luchador.Nombre = (string)dataReader["nombreLuchador"];
                        luchador.IDCasa = (int)dataReader["idCasa"];
                        listadoLuchadores.Add(luchador);
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
            return listadoLuchadores;
        }

    }
}
