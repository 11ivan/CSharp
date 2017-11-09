using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19_BindingListaPersonas.Models;
using _19_BindingListaPersonas.Models.Lists;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _19_BindingListaPersonas.Models.ViewModel
{
    class VMMainPage : INotifyPropertyChanged
    {
        private Persona personaSelected;
        private ListaPersonas listaPersonas;
        public event PropertyChangedEventHandler PropertyChanged;

        public VMMainPage()
        {        
            listaPersonas = new ListaPersonas();
        }


        public ObservableCollection<Persona> ListaPersonas
        {
            get
            {
                return listaPersonas.getListaPersonas();
            }
        }

        public Persona PersonaSelected
        {
            get
            {
                return personaSelected;
            }
            set
            {
                personaSelected = value;
                NotifyPropertyChanged("PersonaSelected");
            }

        }


        private void NotifyPropertyChanged( String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




    }
}
