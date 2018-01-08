﻿using CRUD_Personas_UWP_DAL.Gestoras;
using CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ésta clase se encarga de comunicarse con nuestra capa ui realizando las acciones 
necesarias sobre una persona haciendo uso de nuestra clase GestoraPersonasDAL 
     
*/

namespace CRUD_Personas_UWP_BL.Gestoras
{
    public class GestoraPersonasBL
    {

        /// <summary>
        /// Dado el id de una persona, hace uso de GestoraPersonasDAL para realizar la consulta a la base de datos
        /// con ese id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve la Persona asociada al id</returns>
    /*    public Persona getPersona(int id)
        {
            Persona persona = new Persona();
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            persona=gestoraPersonasDAL.getPersona(id);
            return persona;
        }

        /// <summary>
        /// Dada una persona, hace uso de GestoraPersonasDAL para realizar la actualización
        /// de la persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Un entero que será el número de filas afectadas</returns>
        public int updatePersona(Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            affectedRows = gestoraPersonasDAL.updatePersona(persona);

            return affectedRows;
        }

        /// <summary>
        /// Dado el id de una persona, hace uso de GestoraPersonasDAL para realizar la eliminación
        /// de la persona con ese id en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un entero que será el número de filas afectadas</returns>
        public int deletePersona(int id)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();

            affectedRows= gestoraPersonasDAL.deletePersona(id);
            return affectedRows;
        }

        /// <summary>
        /// Dada una persona, hace uso de GestoraPersonasDAL para realizar la inserción
        /// de la persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Un entero que será el número de filas afectadas</returns>
        public int insertPersona(Persona persona)
        {
            int affectedRows = 0;
            GestoraPersonasDAL gestoraPersonasDAL = new GestoraPersonasDAL();
            affectedRows = gestoraPersonasDAL.insertPersona(persona);
            return affectedRows;
        }

    */
    }
}
