using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Correcion_Ej1_Examen.Models.ViewModels
{
    public class VMMainPage
    {
        #region Propiedades
        private List<Ellipse> _listaEllipses;

        #endregion Propiedades


        public VMMainPage()
        {         
            _listaEllipses = new List<Ellipse>(0);
        }


        #region Getters and Setters
        public List<Ellipse> ListaEllipses
        {
            get
            {
                return _listaEllipses;
            }
            set
            {
                _listaEllipses = value;
            }
        }

        #endregion Getters and Setters  


        #region Metodos de Clase
        /// <summary>
        /// Marca una diferencia en las imagenes, poniendo su opacidad a 1 y añade la elipse a
        /// _listaEllipses para su futuro reseteo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Click_Marca(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;

            ellipse.Opacity = 1;

            if (!_listaEllipses.Contains(ellipse))
            {
                _listaEllipses.Add(ellipse);
            }
            if (_listaEllipses.Count==7)
            {
                //Preguntar si vuelve a jugar
                preguntarSiJuega();
            }
        }

        /// <summary>
        /// Muestra un cuadro de dialogo preguntando si quiere volver a jugar.
        /// </summary>
        public async void preguntarSiJuega()
        {
            ContentDialog contentDialog = new ContentDialog();
            contentDialog.Title = "Volver a jugar";
            contentDialog.Content = "Quiere volver a jugar?";
            contentDialog.PrimaryButtonText = "Si";
            contentDialog.SecondaryButtonText = "No";
            ContentDialogResult result = await contentDialog.ShowAsync();

            if (result==ContentDialogResult.Primary)
            {
                resetEllipses();
            }
        }
        
        /// <summary>
        /// Pone la opacidad de todas las elipses a 0 y la elimina de _listaEllipses
        /// </summary>
        public void resetEllipses()
        {
            for (int i= _listaEllipses.Count;i>0;i--)
            {
                _listaEllipses.ElementAt(0).Opacity = 0;
                _listaEllipses.RemoveAt(0);
            }
        }

        #endregion Metodos de clase

    }
}
