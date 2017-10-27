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
            listaDepartamentos = new List<Departamento>();
        }


        public void addDepartamento(Departamento departamento)
        {
            listaDepartamentos.Add(departamento);
        }

        public Departamento getDepartamento(int idDep)
        {
            Departamento departamento = new Departamento();
            Boolean sal = false;
            for (int i=0;i<listaDepartamentos.Count && !sal;i++)
            {
                if (listaDepartamentos.ElementAt(i).Id==idDep)
                {
                    departamento = listaDepartamentos.ElementAt(i);
                    sal = true;
                }
            }

            return departamento;
        }

        public List<Departamento> getDepartamentos()
        {
            return listaDepartamentos;
        }

       /* public int size()
        {
            int size;
           return size = listaDepartamentos.Count;
        }*/

    }
}