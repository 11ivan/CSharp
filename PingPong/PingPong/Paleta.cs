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
        private  int height;
        private  int width;
        private  int posX;
        private  int posY;
        private int dirX;
        private int dirY;
        private  Rectangle rect;

        public Paleta() {
            height = 100;
            width = 20;
            posX = 0;// 950 player2
            posY = 0;// 100 player2
            dirY = 0;
            rect = new Rectangle();
            rect.Height = height;
            rect.Width = width;
            rect.Fill = new SolidColorBrush(Colors.Blue);
        }

        //Consultores

        public Rectangle getRectangle() {
            return rect;
        }

        public int getPosX()
        {
            return posX;
        }

        public int getPosY()
        {
            return posY;
        }


        //Modificadores
        public void setPosX(int posX)
        {
            this.posX = posX;
        }

        public void setPosY(int posY)
        {
            this.posY = posY;
        }


        public void takePosition()
        {
            Canvas.SetTop(rect, posY);
            Canvas.SetLeft(rect, posX);
        }


        public void move()
        {
            posY += dirY;
            Canvas.SetTop(rect, posY);
        }

        public void down()
        {
            if (posY<500)
            {
                dirY = 10;
            }
            else
            {
                dirY = 0;
            }
        }
        public void up()
        {
            if (posY > 0)
            {
                dirY = -10;
            }
            else
            {
                dirY = 0;
            }
        }

        public void stop()
        {
            dirY = 0;
        }

    }
}
