using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19_BindingListaPersonas.Models;


namespace _19_BindingListaPersonas.Models.Lists
{
    class ListaPersonas    
    {
        public ObservableCollection<Persona> listaPersonas { get; set; }

       /* public ListaPersonas()
        {
            listaPersonas = new ObservableCollection<Persona>();
            Persona p1 = new Persona(0, "Pepe", "Pérez", new DateTime(5, 10, 1990), "C/ sn", "955555555");
            Persona p2 = new Persona(0, "Ganas", "De ná", new DateTime(7, 12, 1989), "C/ sn", "955555123");
            Persona p3 = new Persona(0, "Manolito", "Yeah", new DateTime(25, 1, 1987), "C/ sn", "955555321");
            listaPersonas.Add(p1);
            listaPersonas.Add(p2);
            listaPersonas.Add(p3);
        }*/

        public ListaPersonas()
        {
            listaPersonas = new ObservableCollection<Persona>();
            Persona p1 = new Persona("Pepe", "Pérez", "C/ sn", "955555555");
            Persona p2 = new Persona("Ganas", "De ná", "C/ sn", "955555123");
            Persona p3 = new Persona("Manolito", "Yeah", "C/ sn", "955555321");
            listaPersonas.Add(p1);
            listaPersonas.Add(p2);
            listaPersonas.Add(p3);           
        }

        public ObservableCollection<Persona> getListaPersonas()
        {
            return listaPersonas;
        }


    }
}
