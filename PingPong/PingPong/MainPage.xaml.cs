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

namespace PingPong
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Bola bola;
        DispatcherTimer timer;
        int pointJ1 = 0;
        int pointJ2 = 0;
        Paleta p1;
        Paleta p2;

        public MainPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,1);
            //timer.IsEnabled = true;
            timer.Tick += timertick;
            //timer.Start();
            // bola = new Bola(canvas);
            bola = new Bola();
            bola.tomaPosicion();
            canvas.Children.Add(bola.getEllipse());
            p1 = new Paleta();
            p2 = new Paleta();
            p1.tomaPosicion();
            canvas.Children.Add(p1.getRectangle());
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timertick(object sender, object e) {
            bola.move();
            if (bola.getPosX()<=0) {
                bola.reboteX();
            }
            if (bola.getPosX() >= 575){
                bola.reboteX();
            }

            if (bola.getPosY() <= 0) //|| bola.getPosY() >= 975)
            {
                bola.reboteY();
                pointJ2++;
                player2.Text = Convert.ToString(pointJ2);
            }
            if (bola.getPosY() >= 975) {
                bola.reboteY();
                pointJ1++;
                player1.Text = Convert.ToString(pointJ1);
            }
        }

        /// <summary>
        /// Inicia, Pausa o Continua el DispatcherTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                PlayPause.Content = "Continuar";
                timer.Stop();
            }else {
                PlayPause.Content = "Pause";
                timer.Start();
            }
        }
    }
}
