﻿using System;
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
    class VMMainPage : clsVMBase
    {

        #region region Propiedades

        private Persona _personaSelected;
        private ListaPersonas listaPersonas;
        //public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _commandDelete;

        #endregion

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
                return _personaSelected;
            }
            set
            {
                _personaSelected = value;
                _commandDelete.RaiseCanExecuteChanged();/////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                NotifyPropertyChanged("PersonaSelected");
            }

        }


        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand commandDelete
        {
            get
            {
                _commandDelete = new DelegateCommand(deletePersona, validaDelete);
                return _commandDelete;
            }
        }


        /// <summary>
        /// Metodo para validar si se puede borrar(por si no hay persona seleccionada)
        /// </summary>
        /// <returns></returns>
        public Boolean validaDelete()
        {
            Boolean vale = false;

            if (_personaSelected!=null)
            {
                vale = true;
            }

            return vale;
        }

        /// <summary>
        /// Metodos para eliminar persona de la lista
        /// </summary>
        public void deletePersona()
        {
            listaPersonas.listaPersonas.Remove(_personaSelected);
        }



        /* private void NotifyPropertyChanged( String propertyName)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
             }
         }*/




    }
}
