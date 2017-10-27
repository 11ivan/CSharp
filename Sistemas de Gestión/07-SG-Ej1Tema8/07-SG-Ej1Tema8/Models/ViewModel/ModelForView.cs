using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _07_SG_Ej1Tema8.Models.Entities;
using _07_SG_Ej1Tema8.Models.Lists;


namespace _07_SG_Ej1Tema8.Models.ViewModel
{
    public class ModelForView:Persona
    {
        private ListDepartamentos listaDepartamentos;

        public ModelForView()
        {
            listaDepartamentos = new ListDepartamentos();
        }

        public ListDepartamentos ListDepartamentos
        {
            get
            {
                return this.listaDepartamentos;
            }
            set
            {
                listaDepartamentos = value;
            }
        }
       

    }
}