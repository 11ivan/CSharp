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
    class VMMainPage : clsVMBase
    {

        #region Propiedades

        private Persona personaCreada;
        private Persona _personaSelected;
        private ListaPersonas listaPersonas;
        //public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _commandDelete;
        private DelegateCommand _commandSave;
        private DelegateCommand _commandAdd;
        private DelegateCommand _commandSearch;
        //private ListaPersonas listaPersonasBuscadas;
        private String _campoBusqueda;
        private List<Persona> _filtroPersonas;

#endregion Propiedades

        public VMMainPage()
        {
            _campoBusqueda = "";
            listaPersonas = new ListaPersonas();
            _filtroPersonas = new List<Persona>();
            //listaPersonasBuscadas = new ListaPersonas();
        }


#region Getters and Setters  _personaSelected, listaPersonas, _campoBusqueda, _filtroPersonas
        public ObservableCollection<Persona> ListaPersonas
        {
            get
            {
                return listaPersonas.getListaPersonas();
            }
        }

        /*public ObservableCollection<Persona> ListaPersonasBuscadas
        {
            get
            {
                return listaPersonasBuscadas.getListaPersonas();
            }
        }*/

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
                _commandSave.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSelected");
            }

        }


        public String campoBusqueda
        {
            get
            {
                return _campoBusqueda;
            }
            set
            {
                _campoBusqueda = value;
                if (String.IsNullOrWhiteSpace(_campoBusqueda) && _filtroPersonas.Count>0)
                {
                    //Rellenar la lista con todos los elementos del filtro y vaciar filtro para la proxima busqueda
                    fillListPersonas();
                    emptyFiltroPersonas();
                }
                _commandSearch.RaiseCanExecuteChanged();
                NotifyPropertyChanged("campoBusqueda");
            }
        }

        public List<Persona> filtroPersonas
        {
            get
            {
                return _filtroPersonas;
            }
            set
            {
                _filtroPersonas = value;
            }
        }

#endregion Getters and Setters  _personaSelected, listaPersonas, _campoBusqueda

//--------------------------------------------------------------------------------------------------------------------------------------

#region Getters, Setters and Methods for DelegateCommands
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand commandDelete
        {
            get
            {
                _commandDelete = new DelegateCommand(deletePersona, canDelete);
                return _commandDelete;
            }
        }


        /// <summary>
        /// Metodo para validar si se puede borrar(por si no hay persona seleccionada)
        /// </summary>
        /// <returns></returns>
        public Boolean canDelete()
        {
            Boolean vale = false;

            if (_personaSelected!=null && !String.IsNullOrWhiteSpace(_personaSelected.nombre) && !String.IsNullOrWhiteSpace(_personaSelected.apellido))
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

//--------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand commandSave
        {
            get{
               _commandSave = new DelegateCommand(executeCommandSave, canSave);
                return _commandSave;
            }
        }

        /// <summary>
        /// Comprueba si hay una persona seleccionada en la lista para habilitar el boton de guardar
        /// </summary>
        /// <returns>Un booleano que será verdadero si hay alguna persona seleccionada y false sino</returns>
        public Boolean canSave()
        {
            Boolean puede = false;

            if (_personaSelected!=null && !String.IsNullOrWhiteSpace(_personaSelected.nombre) && !String.IsNullOrWhiteSpace(_personaSelected.apellido))
            {
                puede = true;
            }

            return puede;
        }

        /// <summary>
        /// 
        /// </summary>
        public void executeCommandSave()
        {
            if (!this.exists(_personaSelected.id))
            {
                //_personaSelected.id = listaPersonas.listaPersonas.ElementAt(listaPersonas.listaPersonas.Count-1).id+1;
                listaPersonas.listaPersonas.Add(_personaSelected);
                NotifyPropertyChanged("ListaPersonas");
            }
        }

//--------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand commandAdd
        {
            get
            {
                _commandAdd = new DelegateCommand(addPersona);
                //_commandSave.RaiseCanExecuteChanged();
                return _commandAdd;
            }
        }

        /// <summary>
        /// Crea una nueva persona
        /// </summary>
        public void addPersona()
        {
            _personaSelected = new Persona();
            _commandSave.RaiseCanExecuteChanged();
            _commandDelete.RaiseCanExecuteChanged();
            //listaPersonas.listaPersonas.Add(_personaSelected);
            NotifyPropertyChanged("PersonaSelected");
        }
//--------------------------------------------------------------------------------------------------------------------------


        //Esto sirve cuando mi clase implementa la interfaz INotifyPropertyChanged
        /* private void NotifyPropertyChanged( String propertyName)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
             }
         }*/

        public DelegateCommand commandSearch
        {
            get
            {
                _commandSearch = new DelegateCommand(search, canSearch);
                return _commandSearch;
            }
        }

        /// <summary>
        /// Comprueba si la propiedad _campoBusqueda contiene algún texto
        /// </summary>
        /// <returns>Un booleano que será verdadero si _campoBusqueda contiene algún texto y false sino</returns>
        public Boolean canSearch()
        {
            Boolean puede = false;

            if (!String.IsNullOrWhiteSpace(_campoBusqueda))
            {
                puede = true;
            }
            return puede;
        }

        /// <summary>
        /// Busca en la lista las personas cuyo nombre no contenga la cadena introducida en _campoBusqueda
        /// para pasarlas a _filterPersonas y eliminarlas de listaPersonas
        /// </summary>
        public void search()
        {
            String nombreBuscado = "";
            fillListPersonas();
            emptyFiltroPersonas();
            for (int i=0;i<listaPersonas.listaPersonas.Count;i++)
            {
                nombreBuscado = listaPersonas.listaPersonas.ElementAt(i).nombre;
                
                if (!nombreBuscado.ToLower().Contains(_campoBusqueda.ToLower()))
                {
                    filtroPersonas.Add(listaPersonas.listaPersonas.ElementAt(i));
                    listaPersonas.listaPersonas.RemoveAt(i);
                    NotifyPropertyChanged("ListaPersonas");
                }
            }
        }

#endregion Getters, Setters and Methods for DelegateCommands

        #region Methods For Class


        /// <summary>
        /// Comprueba si una persona ya existe en la lista
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>Un booleano que será verdadero si se encuentra el id de la persona y false sino</returns>
        public Boolean exists(int idPersona)
        {
            Boolean existe = false;
            /* foreach (Persona personaTemp in ListaPersonas)
             {
                 if (personaTemp.id==idPersona)
                 {
                     existe = true;
                 }
             }*/
            for (int i=0;i<ListaPersonas.Count && !existe;i++)
            {
                if (ListaPersonas.ElementAt(i).id==idPersona)
                {
                    existe = true;
                }
            }
            return existe;
        }


        /// <summary>
        /// Rellena la lista de personas con todos los elementos del filtro de personas
        /// </summary>
        public void fillListPersonas()
        {
            foreach (Persona personaTemp in _filtroPersonas)
            {
                listaPersonas.listaPersonas.Add(personaTemp);
            }
        }

        /// <summary>
        /// Vacia el filtro de personas
        /// </summary>
        public void emptyFiltroPersonas()
        {
            foreach (Persona personaTemp in _filtroPersonas)
            {
                _filtroPersonas.Remove(personaTemp);
            }
        }

#endregion


    }
}
