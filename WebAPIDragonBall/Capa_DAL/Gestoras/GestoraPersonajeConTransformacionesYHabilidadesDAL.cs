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
    public class GestoraPersonajeConTransformacionesYHabilidadesDAL
    {

        public List<PersonajeConTransformacionesYHabilidades> getListaPersonajeConTransformacionesYHabilidades()
        {
            List<PersonajeConTransformacionesYHabilidades> listadoPersonajeConTransformacionesYHabilidades = new List<PersonajeConTransformacionesYHabilidades>();
            PersonajeConTransformacionesYHabilidades personajeConTransformacionesYHabilidades;
            GestoraPersonajesDAL gestoraPersonajesDAL = new GestoraPersonajesDAL();
            GestoraTransformacionesDAL gestoraTransformacionesDAL = new GestoraTransformacionesDAL();
            GestoraHabilidadesDAL gestoraHabilidadesDAL = new GestoraHabilidadesDAL();
            List<Personaje> listadoPersonajes = new List<Personaje>();
            List<Transformacion> listadoTransformaciones = new List<Transformacion>();
            List<Habilidad> listadoHabilidades = new List<Habilidad>();

            try
            {                 
                listadoPersonajes = gestoraPersonajesDAL.getListaPersonajes();
                listadoTransformaciones = gestoraTransformacionesDAL.getListaTransformaciones();
                listadoHabilidades = gestoraHabilidadesDAL.getListaHabilidades();
                for (int i=0;i<listadoPersonajes.Count;i++)
                {
                    personajeConTransformacionesYHabilidades = new PersonajeConTransformacionesYHabilidades();
                    personajeConTransformacionesYHabilidades.ID = listadoPersonajes.ElementAt(i).ID;
                    personajeConTransformacionesYHabilidades.Nombre = listadoPersonajes.ElementAt(i).Nombre;                 

                    for (int j=0;j<listadoTransformaciones.Count;j++)
                    {
                        if (listadoTransformaciones.ElementAt(j).IdPersonaje==personajeConTransformacionesYHabilidades.ID)
                        {
                            personajeConTransformacionesYHabilidades.listaTranformaciones.Add(listadoTransformaciones.ElementAt(j));
                        }
                    }
                    for (int j = 0; j < listadoHabilidades.Count; j++)
                    {
                        if (listadoHabilidades.ElementAt(j).IdPersonaje == personajeConTransformacionesYHabilidades.ID)
                        {
                            personajeConTransformacionesYHabilidades.listaHabilidades.Add(listadoHabilidades.ElementAt(j));
                        }
                    }
                    listadoPersonajeConTransformacionesYHabilidades.Add(personajeConTransformacionesYHabilidades);
                }
            }
            catch (Exception e)
            {
                throw e;
            }           
            return listadoPersonajeConTransformacionesYHabilidades;
        }


        /*public Personaje getPersonaje(int id)
        {
            Personaje personaje = new Personaje();
            Conexion conexion = new Conexion();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            SqlParameter parameterID = new SqlParameter();

            try
            {
                conexion.openConnection();
                sqlCommand.Connection = conexion.connection;
                sqlCommand.CommandText = "Select ID, Nombre From Personajes where ID=@id";

                parameterID.ParameterName = "@id";
                parameterID.SqlDbType = System.Data.SqlDbType.Int;
                parameterID.Value = id;
                sqlCommand.Parameters.Add(parameterID);

                dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    personaje.ID = (int)dataReader["ID"];
                    personaje.Nombre = (string)dataReader["Nombre"];

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
            return personaje;
        }*/

    }
}
