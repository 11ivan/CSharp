using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using CRUD_Personas_UWP_Entidades;
using CRUD_Personas_UWP_BL.Listados;
using CRUD_Personas_UWP_BL.Gestoras;
using Windows.UI.Xaml;
using Newtonsoft.Json.Linq;
using Windows.Web.Http;
using System.Threading;

namespace CRUD_Personas_UWP_UI.ViewModels
{
    public class VMMainPage : clsVMBase
    {

#region Propiedades

        private Persona _personaSelected;
        private List<Persona> _listaPersonas;
        //public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _commandDelete;
        private DelegateCommand _commandSave;
        private DelegateCommand _commandAdd;
        private DelegateCommand _commandSearch;
        private DelegateCommand _commandActualizar;
        private String _campoBusqueda;
        private ObservableCollection<Persona> _listaPersonasBinding;
        private DispatcherTimer timer;
        private Boolean _enableProgressRing;

        private ListaPersonasBL listadoPersonasBL = new ListaPersonasBL();
        private GestoraPersonasBL gestoraPersonasBL = new GestoraPersonasBL();

        //DateTimeOffset dateTimeOffset;

#endregion Propiedades

        public VMMainPage()
        {
            EnableProgressRing = true;
            _campoBusqueda = "";
            _listaPersonas = new List<Persona>();
            _listaPersonasBinding = new ObservableCollection<Persona>();
            fillListPersonasBinding();
            timer = new DispatcherTimer();
            startTimer();

            //dateTimeOffset = new DateTimeOffset(_personaSelected.fechaNac);
        }

       


#region Getters and Setters  _personaSelected, listaPersonas, _campoBusqueda, _filtroPersonas

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
                return this._listaPersonasBinding;
            }
            set
            {
                _listaPersonasBinding = value;
                NotifyPropertyChanged("listaPersonasBinding");
            }
        }

        public Boolean EnableProgressRing
        {
            get
            {
                return _enableProgressRing;
            }
            set
            {
                _enableProgressRing = value;
                NotifyPropertyChanged("EnableProgressRing");
            }
        }

#endregion Getters and Setters  _personaSelected, listaPersonas, _campoBusqueda


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

            if (_personaSelected!=null && !String.IsNullOrWhiteSpace(_personaSelected.nombre) && !String.IsNullOrWhiteSpace(_personaSelected.apellidos))
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
            //Preguntar si elimina   
            DeleteAsync();
           
            /*gestoraPersonasBL.deletePersona(_personaSelected.id);
            _listaPersonas.Remove(_personaSelected);
            _listaPersonasBinding.Remove(_personaSelected);
            NotifyPropertyChanged("listaPersonasBinding");*/
        }

        /// <summary>
        /// Muestra un mensaje preguntando si desea eliminar la persona seleccionada
        /// si la respuesta sea Ok la persona será eliminada de la base de datos, 
        /// de _listaPersonas y de _listaPersonasBinding, sino la repuesta será
        /// Close y no se cerrará el cuadro de dialogo
        /// </summary>
        /// <returns></returns>
        public async void DeleteAsync()
        {
            ContentDialog dialog = new ContentDialog();
            ContentDialogResult contentDialogResult = new ContentDialogResult();
            dialog.Title = "Advertencia";
            dialog.Content = "Seguro que desea eliminar al usuario?";
            dialog.CloseButtonText = "Close";
            dialog.PrimaryButtonText = "Ok";

            contentDialogResult= await dialog.ShowAsync();

            if (contentDialogResult==ContentDialogResult.Primary)
            {
                try
                {
                    if (await gestoraPersonasBL.deletePersona(_personaSelected.id) == HttpStatusCode.NoContent)
                    {
                        _listaPersonas.Remove(_personaSelected);
                        _listaPersonasBinding.Remove(_personaSelected);
                        NotifyPropertyChanged("listaPersonasBinding");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
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

            if (_personaSelected!=null /*&& !String.IsNullOrWhiteSpace(_personaSelected.nombre) && !String.IsNullOrWhiteSpace(_personaSelected.apellido)*/)
            {
                puede = true;
            }
            /* else
            {
                canSaveAsync();
            }*/
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
            dialog.Content = "Debe introducir el .....";
            dialog.CloseButtonText = "Close";
            await dialog.ShowAsync();
        }


        /// <summary>
        /// Añade una persona a las listas de personas
        /// </summary>
        public async void executeCommandSave()
        {
            //Si la persona no existe la actualizamos
            if (!this.exists(_personaSelected.id))
            {
                try
                {

                    if (await gestoraPersonasBL.insertPersona(_personaSelected)==HttpStatusCode.Created)//insercion en la base de datos
                    {
                        _listaPersonas.Add(_personaSelected);//añade a la lista original
                        _listaPersonasBinding.Add(_personaSelected);//añade a la lista bindeada
                        NotifyPropertyChanged("listaPersonasBinding");
                    }
                }
                catch (Exception e)
                {
                    //Mostrar mensaje de error al guardar
                }
            }
            else//Sino la actualizamos
            {
                try
                {

                    if (await gestoraPersonasBL.insertPersona(_personaSelected) == HttpStatusCode.Created)//actualizacion en la base de datos
                    {
                        _listaPersonas.Add(_personaSelected);//añade a la lista original
                        _listaPersonasBinding.Add(_personaSelected);//añade a la lista bindeada
                        NotifyPropertyChanged("listaPersonasBinding");
                    }
                }
                catch (Exception e)
                {
                    //Mostrar mensaje de error al guardar
                }

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
                _commandAdd = new DelegateCommand(addPersona/*, canAdd*/);
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
            PersonaSelected = new Persona();
            //_personaSelected = new Persona();
            //_commandSave.RaiseCanExecuteChanged();
            //listaPersonas.listaPersonas.Add(_personaSelected);   //La persona no se añade nada más darle al botón Añadir
            //NotifyPropertyChanged("PersonaSelected");
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
        /// Busca en _listaPersonas las personas cuyo nombre contenga la cadena introducida en _campoBusqueda
        /// para añadirlas a una lista de apoyo la cual servirá para asignarla a _listaPersonasBinding
        /// </summary>
        public void search()
        {
            String nombrePersona = "";
            List<Persona> listaApoyo = new List<Persona>();

            for (int i=0;i<_listaPersonas.Count;i++)
            {
                nombrePersona = _listaPersonas.ElementAt(i).nombre;
                
                if (nombrePersona.ToLower().Contains(_campoBusqueda.ToLower()))
                {
                    listaApoyo.Add(_listaPersonas.ElementAt(i));
                }
            }
            _listaPersonasBinding = new ObservableCollection<Persona>(listaApoyo);
            NotifyPropertyChanged("listaPersonasBinding");
        }

        /// <summary>
        /// Actualiza la lista de personas
        /// </summary>
        public DelegateCommand commandActualizar
        {
            get
            {
                startTimer();
                return _commandActualizar = new DelegateCommand(actualizar);
            }
        }

        /// <summary>
        /// Se encarga de actualizar la lista de Personas por si se ha hecho alguna 
        /// tipo de modificacion ajena en la tabla Personas
        /// </summary>
        public void actualizar()
        {
            EnableProgressRing = true;
            Persona persona = null;

            //Si ya habia una persona seleccionada la asignamos a una temporal
            if (_personaSelected != null)
            {
                persona = _personaSelected;
            }

            //Recargamos la lista de Personas
            fillListPersonasBinding();

            //Si habia algo escrito en el campo de busqueda volvemos a buscar
            if (canSearch())
            {
                search();
            }

            //Si ya habia una persona seleccionada la persona temporal no será null y la volvemos a asignar a _personaSelected
            //Thread.Sleep(1000);
            if (persona != null)
            {
                PersonaSelected = persona;
                //_personaSelected = persona;
                //NotifyPropertyChanged("PersonaSelected");
            }
        }

#endregion Getters, Setters and Methods for DelegateCommands


#region Methods For Class

        /// <summary>
        /// Comprueba si una persona ya existe en la lista Bindeada
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>Un booleano que será verdadero si se encuentra el id de la persona y false sino</returns>
        public Boolean exists(int idPersona)
        {
            Boolean existe = false;
            for (int i=0;i<_listaPersonasBinding.Count && !existe;i++)
            {
                if (_listaPersonasBinding.ElementAt(i).id==idPersona)
                {
                    existe = true;
                }
            }
            return existe;
        }


        /// <summary>
        /// Carga _listaPersonas con las Personas de la tabla Personas, ordena la lista 
        /// y la asigna a _listaPersonasBinding
        /// </summary>
        public async void fillListPersonasBinding()
        {
            try
            {
                _listaPersonas = await listadoPersonasBL.getListaPersonas();
            }
            catch (Exception e)
            {
                throw e;
            }
            _listaPersonas.Sort();
            EnableProgressRing = false;
            _listaPersonasBinding = new ObservableCollection<Persona>(_listaPersonas);
            NotifyPropertyChanged("listaPersonasBinding");
        }

        /// <summary>
        /// Inicia el timer para ejecutar un evento cada 15 segundos
        /// </summary>
       public void startTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 60);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Metodo de dispatcherTimer que se encarga de actualizar la lista de Personas por si se ha hecho alguna 
        /// tipo de modificacion ajena en la tabla Personas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, object e)
        {
            actualizar();
        }

#endregion Methods For Class


    }
}
