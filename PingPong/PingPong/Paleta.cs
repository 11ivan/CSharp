using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

/// <summary>
/// Propiedade Básicas: 
///     Alto: Entero, Consultable, Modificable
///     Ancho: Entero, Consultable, Modificable
///     Posicion X: Entero, Consultable, Modificable
///     Posicion Y: Entero, Consultable, Modificable
/// Propiedades Derivadas:
/// 
/// Propiedades Agregadas:
///     Objeto Rectangle: Consultable , Modificable
/// 
/// </summary>

namespace PingPong
{
    class Paleta{
        private static int height;
        private static int width;
        private static int posX;
        private static int posY;
        private static Rectangle rect;

        public Paleta() {
            height = 100;
            width = 20;
            posX = 0;//100
            posY = 0;//950
            rect = new Rectangle();
            rect.Height = height;
            rect.Width = width;
            rect.Fill = new SolidColorBrush(Colors.Blue);
        }

        //Consultores

        public Rectangle getRectangle() {
            return rect;
        }


        public void tomaPosicion()
        {
            Canvas.SetTop(rect, posX);
            Canvas.SetLeft(rect, posY);
        }


    }
}
