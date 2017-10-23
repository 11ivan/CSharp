using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace UWP_Controls
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,1);
            timer.Tick += timerTick;
        }

        /// <summary>
        ///  Gestiona eventos en un intervalo de tiempo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timerTick(object sender, object e)
        {

        }

        public void changeImage()
        {
            //ImageSource source = new ImageSource;
            switch (image.Tag)
            {
                case 0:
                    image.Source = new Uri("ms:appx///Images/nuevayork.jpg");
                    break;

                case 1:

                    break;

                case 2:

                    break;

            }
        }

        /*private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }*/

        /// <summary>
        /// When the rectangle is pressed change its color randomly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentHost_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Replace the ContentControl's content with a new Rectangle of a random color.
            Rectangle newItem = new Rectangle();
            Random rand = new Random();

            newItem.Height = 200;
            newItem.Width = 200;
            newItem.Fill = new SolidColorBrush(Color.FromArgb(255,(byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));

            ContentHost.Content = newItem;
        }

        /// <summary>
        /// When the Progress Bar is complete, stop the Progress Ring
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (progressBar.Value==100)
            {
                progressRing.IsActive = false;
            }
            else
            {
                progressRing.IsActive = true;
            }
        }














    }
}
