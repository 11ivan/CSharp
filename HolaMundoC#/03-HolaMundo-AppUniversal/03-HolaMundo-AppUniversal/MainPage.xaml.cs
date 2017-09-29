using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _03_HolaMundo_AppUniversal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void PromptDialog(String nombre, String tipo)
        {

            ContentDialog miVentana = new ContentDialog();

            switch (tipo) {
                case "bueno":
                    miVentana.Title = "Bien";
                    miVentana.Content = $"Hola {nombre}";
                    miVentana.PrimaryButtonText = "Allow";
                    miVentana.CloseButtonText = "Block";
                break;

                case "malo":
                    miVentana.Title = "Error";
                    miVentana.Content = "Debe introducir el nombre";
                    miVentana.PrimaryButtonText = "Allow";
                    miVentana.CloseButtonText = "Block";
                break;
            }
            ContentDialogResult result = await miVentana.ShowAsync();
        }

       /* private async void PromptDialogGood(String nombre)
        {
            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = "Muy Biennn",
                Content = "Hola " + nombre,
                CloseButtonText = "Block",
                PrimaryButtonText = "Allow",
            };

            ContentDialogResult result = await locationPromptDialog.ShowAsync();
        }*/


       /* private async void displayDialog(String nombre, String titulo) {
            MessageDialog mensaje = new MessageDialog();
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            String nombre;
            nombre = txtBox.Text;

            if (String.IsNullOrWhiteSpace(nombre))
            {
                PromptDialog(nombre, "malo");
            }
            else {
                PromptDialog(nombre, "bueno");
            }
        }














    }
}
