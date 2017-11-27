using Ejercicio1Examen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Shapes;

/*
Propiedades Agregadas:
    Imagen Original: Tipo Imagen, Consultable, Modificable
    Imagen con Diferencias: Tipo Imagen, Consultable, Modificable
    Lista de aciertos: List<Boolean>, consultable, modificable
    Lista de Elipses: List<Ellipse>, consultable, modificable
    Ellipse pulsada:
     
*/

namespace Ejercicio1Examen.Models.ViewModels
{


    public class VMMainPage
    {
        #region Propiedades
        private Imagen _imagenOriginal;
        private Imagen _imagenDiferencias;
        private List<Boolean> _listaAciertos;
        private List<int> _listaElipses;

        #endregion Propiedades

        public VMMainPage()
        {
            _imagenOriginal = new Imagen("ms-appx:///Assets/Images/Diferencias.jpg");
            _imagenDiferencias = new Imagen("ms-appx:///Assets/Images/Diferencias2.jpg");
            _listaAciertos = new List<bool>(7);
            _listaElipses = new List<int>(7);
            //Le damos trasparencia a todas las ellipses
            OpacityEllipses();
        }

        #region Getters and Setters
        public Imagen ImagenOriginal
        {
            get
            {
                return _imagenOriginal;
            }
            set
            {
                _imagenOriginal = value;
            }
        }

        public Imagen ImagenDiferencias
        {
            get
            {
                return _imagenDiferencias;
            }
            set
            {
                _imagenDiferencias = value;
            }
        }

        public List<Boolean> ListaAciertos
        {
            get
            {
                return _listaAciertos;
            }
            set
            {
                _listaAciertos = value;
            }
        }

        public List<int> ListaElipses
        {
            get
            {
                return _listaElipses;
            }
            set
            {
                _listaElipses = value;
            }
        }

        #endregion Getters and Setters  



        #region Metodos de Clase



        /// <summary>
        /// Marca una diferencia en las imagenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Click_Marca(object sender, RoutedEventArgs e)
        {
           
        }


        /// <summary>
        /// Le da transparencia a todas las ellipses de nuestra lista ellipses
        /// </summary>
        public void OpacityEllipses()
        {
            for (int i=0;i<ListaElipses.Count;i++)
            {
                ListaElipses.Add(0);
            }
        }


        #endregion Metodos de clase


    }
}
