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
    public class GestoraCombatesDAL
    {
        /// <summary>
        /// Devuelve un listado con los copmbates de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Combate> getListaCombates()
        {
            List<Combate> listadoCombates = new List<Combate>();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            Combate combate;

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select idCombate, fechaCombate From combates";
                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        combate = new Combate();
                        combate.ID = (int)dataReader["idCombate"];
                        combate.FechaCombate = (DateTime)dataReader["fechaCombate"];
                        listadoCombates.Add(combate);
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
            return listadoCombates;
        }


        //Metodo para insertar combate

    }
}
