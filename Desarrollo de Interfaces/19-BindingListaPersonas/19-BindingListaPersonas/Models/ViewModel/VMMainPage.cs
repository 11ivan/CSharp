using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19_BindingListaPersonas.Models;
using _19_BindingListaPersonas.Models.Lists;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace _19_BindingListaPersonas.Models.ViewModel
{
    class VMMainPage : clsVMBase
    {

        #region Propiedades

        //private Persona personaCreada;
        private Persona _personaSelected;
        private ListaPersonas listaPersonas;
        //public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _commandDelete;
        private DelegateCommand _commandSave;
        private DelegateCommand _commandAdd;
        private DelegateCommand _commandSearch;
        private String _campoBusqueda;
       // private List<Persona> _filtroPersonas;
        private ListaPersonas _listaPersonasBinding;

#endregion Propiedades

        public VMMainPage()
        {
            _campoBusqueda = "";
            listaPersonas = new ListaPersonas();
            listaPersonas.cargaPersonas();
            //_filtroPersonas = new List<Persona>();
            _listaPersonasBinding = new ListaPersonas();
            //_listaPersonasBinding.cargaPersonas();
            fillListPersonasBinding();
        }


#region Getters and Setters  _personaSelected, listaPersonas, _campoBusqueda, _filtroPersonas
        /*public ObservableCollection<Persona> ListaPersonas
        {
            get
            {
                return listaPersonas.getListaPersonas();
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
                _commandAdd.RaiseCanExecuteChanged();
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
                if (String.IsNullOrWhiteSpace(_campoBusqueda))
                {
                    //Rellenar la lista con todos los elementos del filtro y vaciar filtro para la proxima busqueda
                    //emptyListaPersonasBinding();
                    fillListPersonasBinding();
                    //emptyFiltroPersonas();
                }
                _commandSearch.RaiseCanExecuteChanged();
                NotifyPropertyChanged("campoBusqueda");
            }
        }

        public ObservableCollection<Persona> listaPersonasBinding
        {
            get
            {
                return this._listaPersonasBinding.getListaPersonas();
            }
        }

        /*public List<Persona> filtroPersonas
        {
            get
            {
                return _filtroPersonas;
            }
            set
            {
                _filtroPersonas = value;
            }
        }*/

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
            listaPersonas.getListaPersonas().Remove(_personaSelected);
            _listaPersonasBinding.getListaPersonas().Remove(_personaSelected);

            //Ordena();
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
            else
            {
                canSaveAsync();
            }
            return puede;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async void canSaveAsync()
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Error";
            dialog.Content = "Debe introducir el apellido";
            dialog.CloseButtonText = "Close";
            await dialog.ShowAsync();
        }


        /// <summary>
        /// Añade una persona a las listas de personas
        /// </summary>
        public void executeCommandSave()
        {
            if (!this.exists(_personaSelected.id))
            {
                //_personaSelected.id = listaPersonas.listaPersonas.ElementAt(listaPersonas.listaPersonas.Count-1).id+1;
                listaPersonas.getListaPersonas().Add(_personaSelected);
                _listaPersonasBinding.getListaPersonas().Add(_personaSelected);
                //NotifyPropertyChanged("listaPersonasBinding");

                //Ordena();
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
                _commandAdd = new DelegateCommand(addPersona, canAdd);
                //_commandSave.RaiseCanExecuteChanged();
                return _commandAdd;
            }
        }

        public Boolean canAdd()
        {
            Boolean puede = false;
            if (_personaSelected!=null)
            {
                puede = true;
            }
            return puede;
        }

        /// <summary>
        /// Crea una nueva persona
        /// </summary>
        public void addPersona()
        {
            _personaSelected = new Persona();
            //_commandSave.RaiseCanExecuteChanged();
            _commandDelete.RaiseCanExecuteChanged();
            //listaPersonas.listaPersonas.Add(_personaSelected);   //La persona no se añade nada más darle al botón Añadir
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
            String nombrePersona = "";
            if (_listaPersonasBinding.getListaPersonas().Count!=listaPersonas.getListaPersonas().Count)
            {
                fillListPersonasBinding();
            }
            //emptyListaPersonasBinding();
            for (int i=0;i<_listaPersonasBinding.getListaPersonas().Count;i++)
            {
                nombrePersona = _listaPersonasBinding.getListaPersonas().ElementAt(i).nombre;
                
                if (!nombrePersona.ToLower().Contains(_campoBusqueda.ToLower()))
                {
                    //filtroPersonas.Add(listaPersonas.getListaPersonas().ElementAt(i));
                    //listaPersonas.getListaPersonas().RemoveAt(i);
                    //NotifyPropertyChanged("ListaPersonas");

                    _listaPersonasBinding.getListaPersonas().RemoveAt(i);

                    //_listaPersonasBinding.getListaPersonas().Add(listaPersonas.getListaPersonas().ElementAt(i));
                    //NotifyPropertyChanged("listaPersonasBinding");
                }
            }
           // _listaPersonasBinding.getListaPersonas().RemoveAt(_listaPersonasBinding.getListaPersonas().Count-1);  //¡¡CAÑÓN MATAMOSCAS!!  Y TAMPOCO!!!!!!!!
        }

#endregion Getters, Setters and Methods for DelegateCommands

#region Methods For Class


        /// <summary>
        /// Comprueba si una persona ya existe en la lista Bindeada
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>Un booleano que será verdadero si se encuentra el id de la persona y false sino</returns>
        public Boolean exists(Guid idPersona)
        {
            Boolean existe = false;
            for (int i=0;i<_listaPersonasBinding.getListaPersonas().Count && !existe;i++)
            {
                if (_listaPersonasBinding.getListaPersonas().ElementAt(i).id.Equals(idPersona))
                {
                    existe = true;
                }
            }
            return existe;
        }


        /// <summary>
        /// Rellena la lista de personas Bindeada con todos los elementos de la lista de personas original que no estén ya
        /// </summary>
        public void fillListPersonasBinding()
        {
            foreach (Persona personaTemp in listaPersonas.getListaPersonas())
            {
                //listaPersonas.listaPersonas.Add(personaTemp);
                if (!exists(personaTemp.id))
                {
                    _listaPersonasBinding.getListaPersonas().Add(personaTemp);
                }
            }
           // Ordena();
        }

        public void Ordena()
        {
            List<Persona> listaTemp = new List<Persona>();
            foreach (Persona personaTemp in _listaPersonasBinding.getListaPersonas())
            {
                listaTemp.Add(personaTemp);
            }
            listaTemp.Sort();
            emptyListaPersonasBinding();
            foreach (Persona personaTemp2 in listaTemp)
            {
                _listaPersonasBinding.getListaPersonas().Add(personaTemp2);
            }
            _listaPersonasBinding.getListaPersonas().RemoveAt(0);       //Y OTRO CAÑONAZO
        }

        /// <summary>
        /// Vacia el filtro de personas
        /// </summary>
        public void emptyListaPersonasBinding()
        {
            /*foreach (Persona personaTemp in _listaPersonasBinding.getListaPersonas())
            {
                _listaPersonasBinding.getListaPersonas().Remove(personaTemp);
            }*/
           
            for (int i=0;i<_listaPersonasBinding.getListaPersonas().Count;i++)
            {
                _listaPersonasBinding.getListaPersonas().RemoveAt(i);
            }
        }

#endregion


    }
}
