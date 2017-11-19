using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _19_BindingListaPersonas
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.nombrePersona.Text))
            {
                ErrorDialog(1);
            }
            else
            {

                this.nombrePersona.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }

            if (String.IsNullOrWhiteSpace(this.apellidoPersona.Text))
            {
                ErrorDialog(2);
            }
            else
            {
                this.apellidoPersona.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            
            this.telefonoPersona.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.direccionPersona.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }


        private async void ErrorDialog(int error)
        {
            ContentDialog dialog = new ContentDialog();

            switch (error)
            {
                case 1:
                    dialog.Title = "Error";
                    dialog.Content = "Debe introducir el nombre";
                    dialog.CloseButtonText = "Close";
                    break;

                case 2:
                    dialog.Title = "Error";
                    dialog.Content = "Debe introducir el apellido";
                    dialog.CloseButtonText = "Close";
                break;
            }
            
            await dialog.ShowAsync();
        }


    }
}
