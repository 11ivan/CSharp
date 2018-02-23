using Capa_BL.Gestoras;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonajesDragonBallSuper.ViewModels
{
    public class VMMainPage:clsVMBase
    {

        private ObservableCollection<PersonajeConTransformacionesYHabilidades> observableCollectionPersonajes { get; set; }
        private PersonajeConTransformacionesYHabilidades personajeSeleccionado { get; set; }
        private GestoraPersonajeConTransformacionesYHabilidadesBL gestoraPersonajeConTransformacionesYHabilidades = new GestoraPersonajeConTransformacionesYHabilidadesBL();
        private List<String> listaRutasImagenes;

        public VMMainPage()
        {
            listaRutasImagenes = new List<string>();
            observableCollectionPersonajes = new ObservableCollection<PersonajeConTransformacionesYHabilidades>();
            cargaListaPersonajes();
        }


        public ObservableCollection<PersonajeConTransformacionesYHabilidades> ObservableCollectionPersonajes
        {
            get
            {
                return this.observableCollectionPersonajes;
            }
            set
            {
                this.observableCollectionPersonajes = value;
                NotifyPropertyChanged("ObservableCollectionPersonajes");
            }
        }

        public PersonajeConTransformacionesYHabilidades PersonajeSeleccionado
        {
            get
            {
                return this.personajeSeleccionado;
            }
            set
            {
                this.personajeSeleccionado = value;
                NotifyPropertyChanged("PersonajeSeleccionado");
                cargaTransformacionesPersonaje();
            }
        }

        public List<String> ListadoRutasImagenesPersonajeSeleccionado
        {
            get
            {
                return listaRutasImagenes;
            }
            set
            {
                this.listaRutasImagenes = value;
                NotifyPropertyChanged("ListadoRutasImagenesPersonajeSeleccionado");
            }
        }

        public async void cargaListaPersonajes()
        {
            List<PersonajeConTransformacionesYHabilidades> listPersonajes = await gestoraPersonajeConTransformacionesYHabilidades.getListaPersonajeConTransformacionesYHabilidades();
            ObservableCollectionPersonajes = new ObservableCollection<PersonajeConTransformacionesYHabilidades>(listPersonajes);          
        }

        public void cargaTransformacionesPersonaje()
        {
            for (int i=0;i<personajeSeleccionado.listaTranformaciones.Count;i++)
            {
                ListadoRutasImagenesPersonajeSeleccionado.Add(personajeSeleccionado.listaTranformaciones.ElementAt(i).RutaImagen);
            }
        }







    }
}
