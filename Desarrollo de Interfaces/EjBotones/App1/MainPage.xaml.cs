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
using Windows.UI;
using Windows.UI.Text;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace App1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Button boton3 = new Button();
            boton3.Content = "Boton 3";
            boton3.VerticalAlignment = VerticalAlignment.Center;
            boton3.HorizontalAlignment = HorizontalAlignment.Center;
            boton3.Background = new SolidColorBrush(Colors.Blue);
            boton3.BorderBrush = new SolidColorBrush(Colors.Yellow);
            boton3.FontWeight = FontWeights.Bold;
            boton3.FontFamily = new FontFamily("Verdana");
            boton3.FontSize = 16;
            boton3.Width = 200;
            boton3.Height = 70;
            Panel.Children.Add(boton3);
            boton3.Click += Boton3_Click;
        }


        private void Boton3_Click(Object sender, RoutedEventArgs even)
        {
            this.boton2.Content = "No cambia";
        }

    }
}
