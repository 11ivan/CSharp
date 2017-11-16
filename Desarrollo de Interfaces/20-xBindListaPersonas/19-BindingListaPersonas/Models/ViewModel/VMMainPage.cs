using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19_BindingListaPersonas.Models;
using _19_BindingListaPersonas.Models.Lists;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace _19_BindingListaPersonas.Models.ViewModel
{
   public class VMMainPage : INotifyPropertyChanged
    {
        private Persona personaSelected;
        private ListaPersonas listaPersonas;
        private int _indexPersona;
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

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_indexPersona>=0) {
                ListaPersonas.RemoveAt(_indexPersona);
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

        public int IndexPersona
        {
            get{
                return _indexPersona;
            }
            set
            {
                _indexPersona = value;
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
