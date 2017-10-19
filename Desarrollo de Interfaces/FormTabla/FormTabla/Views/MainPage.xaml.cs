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

namespace _FormTabla
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
        /// Si todos los datos del formulario son correctos hace una llamada al método PromptDialog()
        /// evento asiciado al boton "button_Click"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e){

            if (this.compruebaForm()) {
                PromptDialog();
            }
        }


        /// <summary>
        /// Comprueba que los datos del formulario sean correctos
        /// </summary>
        /// <returns>Devuelve un booleano que será verdadero si todos los datos del formulario son correctos y false sino</returns>
        public Boolean compruebaForm() {
            Boolean vale = true;
            DateTime fehcaPars = new DateTime();

            if (String.IsNullOrWhiteSpace(txtNombre.Text)){
                ErrorNombre.Text = "Debe introducir el nombre";
                vale = false;
            }else{
                ErrorNombre.Text = "";
            }

            if (String.IsNullOrWhiteSpace(txtApellido.Text)){
                ErrorApellido.Text = "Debe introducir el apellido";
                vale = false;
            }else{
                ErrorApellido.Text = "";
            }

            if (String.IsNullOrWhiteSpace(txtFechaNac.Text)) {
                ErrorFechaNac.Text = "Debe introducir la fecha";
                vale = false;
            } else if (!DateTime.TryParse(txtFechaNac.Text, out fehcaPars)) {
                ErrorFechaNac.Text = "La fecha no es correcta";
                vale = false;
            } else if (getAge()==-1) {
                ErrorFechaNac.Text = "La fecha no puede ser mayor a la actual";
                vale = false;
            }
            else {
                ErrorFechaNac.Text = "";
            }

            return vale;
        }

        /// <summary>
        /// Muestra una ventana con el nombre, apellido y edad
        /// </summary>
        private async void PromptDialog(){
            ContentDialog miVentana = new ContentDialog();
            miVentana.Title = "Me alegra tenerte aquí";
            miVentana.Content = "Hola "+txtNombre.Text+" "+txtApellido.Text+", tienes "+ getAge()+" años";
            //miVentana.PrimaryButtonText = "Allow";
            miVentana.CloseButtonText = "Close";                           
            ContentDialogResult result = await miVentana.ShowAsync();
        }

        /// <summary>
        ///     Da la diferencia en años entre la fecha actual y la recogida en el textBox Fecha Nacimiento
        /// </summary>
        /// <preconditions>
        ///     La fecha recogida en el textBox Fecha Nacimiento es correcta
        /// </preconditions>
        /// <returns>
        ///     Un entero que será la diferncia en años, -1 en el caso de que la fecha de nacimiento sea mayor a la actual
        /// </returns>
        public int getAge() {
            int age = 0;
            DateTime fechaNac = DateTime.Parse(txtFechaNac.Text);
            DateTime fechaAct = DateTime.Now;
            TimeSpan ts = fechaAct - fechaNac;

            //Si la diferencia en dias es menor que 0 es que la fecha introducida es mayor a la actual
            if (ts.Days < 0) //|| fechaNac.Year==fechaAct.Year && fechaNac.Month == fechaAct.Month && fechaNac.Day == fechaAct.Day)
            {
                age = -1;
            }else{
                age = ts.Days / 365;
                if (fechaNac.Month == fechaAct.Month && fechaNac.Day > fechaAct.Day)
                {
                    age--;
                }
            }
            return age;
        }


    }
}
