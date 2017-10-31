using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _07_SG_Ej1Tema8.Models.Entities;

namespace _07_SG_Ej1Tema8.Models.Lists
{
    public class ListDepartamentos
    {
        private List<Departamento> listaDepartamentos;

        public ListDepartamentos()
        {
            Departamento dep1 = new Departamento("Informática", 1);
            Departamento dep2 = new Departamento("Ciencias", 2);
            Departamento dep3 = new Departamento("Investigación", 3);
            Departamento dep4 = new Departamento("Física", 4);  
            listaDepartamentos = new List<Departamento>();
            listaDepartamentos.Add(dep1);
            listaDepartamentos.Add(dep2);
            listaDepartamentos.Add(dep3);
            listaDepartamentos.Add(dep4);
        }


        /// <summary>
        /// Add departamnet to List
        /// </summary>
        /// <param name="departamento"></param>
        public void addDepartamento(Departamento departamento)
        {
            listaDepartamentos.Add(departamento);
        }


        /// <summary>
        /// Search departament by id and return this 
        /// </summary>
        /// <param name="idDep"></param>
        /// <returns></returns>
        public Departamento getDepartamento(int idDep)
        {
            Departamento departamento = new Departamento();
            Boolean sal = true;
            for (int i=0;i<listaDepartamentos.Count && sal;i++)
            {
                if (listaDepartamentos.ElementAt(i).Id==idDep)
                {
                    departamento = listaDepartamentos.ElementAt(i);
                    sal = false;
                }
            }

            return departamento;
        }



        /// <summary>
        /// Return the complete departament list
        /// </summary>
        /// <returns></returns>
        public List<Departamento> getDepartamentos()
        {
            return listaDepartamentos;
        }

    }
}