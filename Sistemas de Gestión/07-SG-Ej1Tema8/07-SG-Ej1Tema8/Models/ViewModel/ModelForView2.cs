using _07_SG_Ej1Tema8.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_SG_Ej1Tema8.Models.ViewModel
{
    public class ModelForView2:Persona
    {
        private Departamento departamento;


        public ModelForView2()
        {
            departamento = new Departamento();
        }


        public Departamento Departamen
        {
            get
            {
                return departamento;
            }
            set
            {
                departamento = value;
            }
        }


    }
}