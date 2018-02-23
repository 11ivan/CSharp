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
    public class GestoraClasificacionCombateDAL
    {
        /// <summary>
        /// Inserta una clasificacion de comabate en la base de datos
        /// </summary>
        /// <param name="clasificacionCombate"></param>
        /// <returns></returns>
        public int insertClasificacionCombate(ClasificacionCombate clasificacionCombate)
        {
            int affectedRows = 0;
            Conexion conexion = new Conexion();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO clasificacionComabate values(@idCombate, @puntos, @idCategoriaPremio, @idLuchador)";
            SqlParameter idCombate = new SqlParameter();
            SqlParameter puntos = new SqlParameter();
            SqlParameter idCategoriaPremio = new SqlParameter();
            SqlParameter idLuchador = new SqlParameter();            

            try
            {
                conexion.openConnection();
                command.Connection = conexion.connection;

                idCombate.ParameterName = "@idCombate";
                idCombate.SqlDbType = System.Data.SqlDbType.Int;
                idCombate.SqlValue = clasificacionCombate.ID;

                puntos.ParameterName = "@puntos";
                puntos.SqlDbType = System.Data.SqlDbType.Int;
                puntos.SqlValue = clasificacionCombate.Puntos;

                idCategoriaPremio.ParameterName = "@idCategoriaPremio";
                idCategoriaPremio.SqlDbType = System.Data.SqlDbType.Int;
                idCategoriaPremio.SqlValue = clasificacionCombate.IDCategoriaPremio;

                idLuchador.ParameterName = "@idLuchador";
                idLuchador.SqlDbType = System.Data.SqlDbType.Int;
                idLuchador.Value = clasificacionCombate.IDLuchador;

                command.Parameters.Add(idCombate);
                command.Parameters.Add(puntos);
                command.Parameters.Add(idCategoriaPremio);
                command.Parameters.Add(idLuchador);


                affectedRows = command.ExecuteNonQuery();

                conexion.connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return affectedRows;
        }

    }
}
