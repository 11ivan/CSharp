﻿using Capa_DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.Listados
{
    public class ListadoCursosBL
    {

        /// <summary>
        /// Ofrece un listado con los cursos de la base de datos
        /// </summary>
        /// <returns>List<Curso></returns>
        public List<Curso> getListadoCursos()
        {
            List<Curso> listadoCursos = new List<Curso>();
            ListadoCursosDAL listadoCursosDAL = new ListadoCursosDAL();

            try
            {
                listadoCursos = listadoCursosDAL.getListadoCursos();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoCursos;
        }

    }
}
