using CapaBL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJuegoDeTronos.ViewModels
{
    public class VMMainPage:clsVMBase
    {

        #region Propiedades
        private ObservableCollection<Combate> observableCombates;
        private Combate combateSeleccionado;
        private ObservableCollection<Luchador> observableLuchadores1;
        private ObservableCollection<Luchador> observableLuchadores2;
        private Luchador luchadorSeleccionado1;
        private Luchador luchadorSeleccionado2;
        private String imageLuchadorSeleccionado1;
        private String imageLuchadorSeleccionado2;
        private String imageCasaLuchadorSeleccionado1;
        private String imageCasaLuchadorSeleccionado2;
        private String nombreCasaLuchadorSeleccionado1;
        private String nombreCasaLuchadorSeleccionado2;
        private GestoraCombatesBL gestoraCombatesBL = new GestoraCombatesBL();
        private GestoraLuchadoresBL gestoraLuchadoresBL = new GestoraLuchadoresBL();
        private GestoraCasasBL gestoraCasasBL = new GestoraCasasBL();
        private GestoraClasificacionCombateBL gestoraClasificacionCombateBL = new GestoraClasificacionCombateBL();
        private GestoraCategoriasPremiosBL gestoraCategoriasPremiosBL = new GestoraCategoriasPremiosBL();
        private List<CategoriaPremio> listadoCategoriasPremiosLuchadorSeleccionado;
        private DelegateCommand _commandSave;
        #endregion Propiedades


        //
        #region Constructores
        public VMMainPage()
        {
            observableCombates = new ObservableCollection<Combate>();
            observableLuchadores1 = new ObservableCollection<Luchador>();
            observableLuchadores2 = new ObservableCollection<Luchador>();
            listadoCategoriasPremiosLuchadorSeleccionado = new List<CategoriaPremio>();
            //Cargar Observables
            cargaObservableCombates();
            cargaObservablesLuchadores();
            //Cargar CategoriasPremios
            cargaListadosCategoriasPremios();
        }


        #endregion Constructores


        //
        #region Getters and Setters
        public ObservableCollection<Combate> ObservableCombates
        {
            get
            {
                return observableCombates;
            }
            set
            {
                this.observableCombates = value;
                NotifyPropertyChanged("ObservableCombates");
            }
        }

        public Combate CombateSeleccionado
        {
            get
            {
                return combateSeleccionado;
            }
            set
            {
                combateSeleccionado = value;
                NotifyPropertyChanged("CombateSeleccionado");
                _commandSave.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Luchador> ObservableLuchadores1
        {
            get
            {
                return observableLuchadores1;
            }
            set
            {
                this.observableLuchadores1 = value;
                NotifyPropertyChanged("ObservableLuchadores1");
            }
        }
        public ObservableCollection<Luchador> ObservableLuchadores2
        {
            get
            {
                return observableLuchadores2;
            }
            set
            {
                this.observableLuchadores2 = value;
                NotifyPropertyChanged("ObservableLuchadores2");
            }
        }
        public Luchador LuchadorSeleccionado1
        {
            get
            {
                return luchadorSeleccionado1;
            }
            set
            {
                this.luchadorSeleccionado1 = value;
                NotifyPropertyChanged("LuchadorSeleccionado1");
                //Cargar la imagen del luchador, su casa y nombre de esta
                cargaNombreCasaLuchador(1);
                cargaImageCasaYLuchador(1);
                _commandSave.RaiseCanExecuteChanged();
            }
        }
        public Luchador LuchadorSeleccionado2
        {
            get
            {
                return luchadorSeleccionado2;
            }
            set
            {
                this.luchadorSeleccionado2 = value;
                NotifyPropertyChanged("LuchadorSeleccionado2");
                //Cargar la imagen del luchador, su casa y nombre de esta
                cargaNombreCasaLuchador(2);
                cargaImageCasaYLuchador(2);
                _commandSave.RaiseCanExecuteChanged();
            }
        }
        public String ImageLuchadorSeleccionado1
        {
            get
            {
                return imageLuchadorSeleccionado1;
            }
            set
            {
                this.imageLuchadorSeleccionado1 = value;
                NotifyPropertyChanged("ImageLuchadorSeleccionado1");
            }
        }
        public String ImageLuchadorSeleccionado2
        {
            get
            {
                return imageLuchadorSeleccionado2;
            }
            set
            {
                this.imageLuchadorSeleccionado2 = value;
                NotifyPropertyChanged("ImageLuchadorSeleccionado2");
            }
        }
        public String ImageCasaLuchadorSeleccionado1
        {
            get
            {
                return imageCasaLuchadorSeleccionado1;
            }
            set
            {
                this.imageCasaLuchadorSeleccionado1 = value;
                NotifyPropertyChanged("ImageCasaLuchadorSeleccionado1");
            }
        }
        public String ImageCasaLuchadorSeleccionado2
        {
            get
            {
                return imageCasaLuchadorSeleccionado2;
            }
            set
            {
                this.imageCasaLuchadorSeleccionado2 = value;
                NotifyPropertyChanged("ImageCasaLuchadorSeleccionado2");
            }
        }
        public String NombreCasaLuchadorSeleccionado1
        {
            get
            {
                return nombreCasaLuchadorSeleccionado1;
            }
            set
            {
                this.nombreCasaLuchadorSeleccionado1 = value;
                NotifyPropertyChanged("NombreCasaLuchadorSeleccionado1");
            }
        }
        public String NombreCasaLuchadorSeleccionado2
        {
            get
            {
                return nombreCasaLuchadorSeleccionado2;
            }
            set
            {
                this.nombreCasaLuchadorSeleccionado2 = value;
                NotifyPropertyChanged("NombreCasaLuchadorSeleccionado2");
            }
        }

        public List<CategoriaPremio> ListadoCategoriasPremiosLuchadorSeleccionado
        {
            get
            {
                return listadoCategoriasPremiosLuchadorSeleccionado;
            }
            set
            {
                listadoCategoriasPremiosLuchadorSeleccionado = value;
                NotifyPropertyChanged("ListadoCategoriasPremiosLuchadorSeleccionado");
            }
        }
       
        #endregion Getters and Setters

        //DelegateCommand Guardar
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand CommandSave
        {
            get
            {
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

            if (combateSeleccionado!=null && luchadorSeleccionado1!=null && luchadorSeleccionado2!=null && luchadorSeleccionado1.ID!=luchadorSeleccionado2.ID)
            {
                puede = true;
            }            
            return puede;
        }       

        /// <summary>
        /// Añade una persona a las listas de personas
        /// </summary>
        public void executeCommandSave()
        {
            guardarClasificacionLuchador(1);
            guardarClasificacionLuchador(2);
        }
        /// <summary>
        /// Inserta las clasificaciones del combate de los luchadores
        /// </summary>
        public void guardarClasificacionLuchador(int luchador)
        {
            ClasificacionCombate clasificacionCombate = new ClasificacionCombate();
            int generado = 0;
            bool vale = false;
            try
            {
                //Esto es el id del combate
                clasificacionCombate.ID = combateSeleccionado.ID;
                if (luchador == 1)
                {
                    clasificacionCombate.IDLuchador = luchadorSeleccionado1.ID;
                    vale = true;
                    generado = 5;
                }
                else if (luchador == 2)
                {
                    clasificacionCombate.IDLuchador = luchadorSeleccionado2.ID;
                    vale = true;
                    generado = 10;
                }
                if (vale)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        clasificacionCombate.IDCategoriaPremio = listadoCategoriasPremiosLuchadorSeleccionado.ElementAt(i).ID;
                        clasificacionCombate.Puntos = generado;                        
                        gestoraClasificacionCombateBL.insertClasificacionCombate(clasificacionCombate);
                    }
                }
            }
            catch (Exception e)
            {
                //Mostrar mensaje de error al guardar
            }
        }    

        /// <summary>
        /// Carga el observableCollections de combates
        /// </summary>
        public void cargaObservableCombates()
        {
            ObservableCombates = new ObservableCollection<Combate>(gestoraCombatesBL.getListaCombates());
        }

        /// <summary>
        /// Carga los observableCollections de Luchadores
        /// </summary>
        public void cargaObservablesLuchadores()
        {
            List<Luchador> list = new List<Luchador>();
            list = gestoraLuchadoresBL.getListaLuchadores();
            ObservableLuchadores1 = new ObservableCollection<Luchador>(list);
            ObservableLuchadores2 = new ObservableCollection<Luchador>(list);
        }

        /// <summary>
        /// Carga la imagen de la casa y del luchador 1
        /// </summary>
        public void cargaImageCasaYLuchador(int luchador)
        {
            if (luchador==1)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (luchadorSeleccionado1.ID == i)
                    {
                        ImageLuchadorSeleccionado1 = "ms-appx:///Assets/Images/Luchadores/" + i + ".jpg";
                    }
                    if (luchadorSeleccionado1.IDCasa == i)
                    {
                        ImageCasaLuchadorSeleccionado1 = "ms-appx:///Assets/Images/Casas/" + i + ".png";
                    }
                }
            }
            else if (luchador == 2)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (luchadorSeleccionado2.ID == i)
                    {
                        ImageLuchadorSeleccionado2 = "ms-appx:///Assets/Images/Luchadores/" + i + ".jpg";
                    }
                    if (luchadorSeleccionado2.IDCasa == i)
                    {
                        ImageCasaLuchadorSeleccionado2 = "ms-appx:///Assets/Images/Casas/" + i + ".png";
                    }
                }
            }           
        }
        

        /// <summary>
        /// Carga el nombre de la casa del luchador 1
        /// </summary>
        public void cargaNombreCasaLuchador(int luchador)
        {
            if (luchador==1)
            {
                NombreCasaLuchadorSeleccionado1 = gestoraCasasBL.getCasa(luchadorSeleccionado1.IDCasa).Nombre;
            }
            else if(luchador==2)
            {
                NombreCasaLuchadorSeleccionado2 = gestoraCasasBL.getCasa(luchadorSeleccionado2.IDCasa).Nombre;
            }
            
        }
       
        /// <summary>
        /// Carga los listados de categorias para los luchadores
        /// </summary>
        public void cargaListadosCategoriasPremios()
        {
            List<CategoriaPremio> list = gestoraCategoriasPremiosBL.getListaCategoriasPremios();
            ListadoCategoriasPremiosLuchadorSeleccionado = list;
        }



    }
}
