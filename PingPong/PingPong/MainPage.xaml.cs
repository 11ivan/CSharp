using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
            bola.takePosition();
            canvas.Children.Add(bola.getEllipse());
            p1 = new Paleta();
            p2 = new Paleta();
            p1.setPosX(20);
            p1.setPosY(100);
            p2.setPosX(950);
            p2.setPosY(100);

            p1.takePosition();
            p2.takePosition();
            canvas.Children.Add(p1.getRectangle());
            canvas.Children.Add(p2.getRectangle());
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timertick(object sender, object e) {
            bola.move();
            p1.move();
            p2.move();
            this.compruebaRebote();   
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

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key==VirtualKey.Down)
            {
                p2.down();
            }

            if (e.Key==VirtualKey.Up)
            {
                p2.up();
            }

            if (e.Key == VirtualKey.S)
            {
                p1.down();
            }         

            if (e.Key == VirtualKey.W)
            {
                p1.up();
            }
        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Down)
             {
                 p2.stop();
             }

             if (e.Key == VirtualKey.Up)
             {
                 p2.stop();
             }

             if (e.Key == VirtualKey.S)
             {
                 p1.stop();
             }

             if (e.Key == VirtualKey.W)
             {
                 p1.stop();
             }
        }


        //Metodo compruebaRebote
        /// <summary>
        /// 
        /// </summary>
        public void compruebaRebote()
        {
            if (bola.getPosY() <= 0 || bola.getPosY() >= 575)
            {
                bola.reboteY();
            }
            if (bola.getPosX() <= 0) //|| bola.getPosY() >= 975)
            {
                bola.reboteX();
                this.sumaPuntos(2);
                
            }
            if (bola.getPosX() >= 975)
            {
                bola.reboteX();
                this.sumaPuntos(1);
                
            }
            if (bola.getPosX() <= (p1.getRectangle().Width + p1.getPosX()) && bola.getPosY() >= p1.getPosY() && bola.getPosY() <= (p1.getRectangle().Height + p1.getPosY()))
            {
                bola.reboteX();
            }
            if ((bola.getPosX() + bola.getSize()) >= p2.getPosX() && bola.getPosY() >= p2.getPosY() && bola.getPosY() <= (p2.getRectangle().Height + p2.getPosY()))
            {
                bola.reboteX();
            }
        }



        //Metodo sumaPuntos
        public void sumaPuntos(int player)
        {
            switch (player)
            {
                case 1:
                    pointJ1++;
                    player1.Text = Convert.ToString(pointJ1);
                    break;

                case 2:
                    pointJ2++;
                    player2.Text = Convert.ToString(pointJ2);
                    break;
            }
        }



    }
}
