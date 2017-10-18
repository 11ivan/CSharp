using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

/// <summary>
/// Propiedades Básicas: 
///          Posicion X: Entero, Consultable, Modificable 
///          Posicion Y: Entero, Consultable, Modificable 
///          Tamaño: Entero, Consultable, Modificable 
///          Velocidad Movimiento: Entero, Consultable , Modificable
///          
/// Propiedades Derivadas:
/// 
/// 
/// Propiedades Agregadas: 
///         Ellipse
///         
///         
/// </summary>

public class Bola
{

    private  int posX;
    private  int posY;
    private  int dirX, dirY;
    private  int size;
    private  Ellipse ellip;
    private  int speedMove;


    //Constructor de la bola
    /*public Bola(Canvas canvas)
    {
        ellip = new Ellipse();
        posX = 80;
        posY = 80;
        size = 25;
        ellip.Fill = new SolidColorBrush(Colors.Blue);
        ellip.Width = size;
        ellip.Height = size;
        Canvas.SetTop(ellip, posX);
        Canvas.SetLeft(ellip, posY);
        canvas.Children.Add(ellip);

    }*/
    public Bola()
    {
        ellip = new Ellipse();
        posX = 80;
        posY = 80;
        size = 25;
        ellip.Fill = new SolidColorBrush(Colors.Blue);
        ellip.Width = size;
        ellip.Height = size;
        speedMove = 10;
        dirX = speedMove;
        dirY = speedMove;
    }


    //Consultores
    public int getSize()
    {
        return size;
    }

    public int getPosX()
    {
        return posX;
    }

    public int getPosY()
    {
        return posY;
    }

    public Ellipse getEllipse() {
        return ellip;
    }

    //Modificadores

    /* public void setSize(int size) {

     }*/


    //Métodos

    /// <summary>
    /// 
    /// </summary>
    public void move() {
        //posX += speedMove;
        //posY += speedMove;
        posX += dirX;
        posY += dirY;
        Canvas.SetTop(ellip, posY);
        Canvas.SetLeft(ellip, posX);
    }


    /// <summary>
    /// 
    /// </summary>
    public void takePosition() {
        Canvas.SetTop(ellip, posY);
        Canvas.SetLeft(ellip, posX);
    }

    /// <summary>
    /// 
    /// </summary>
    public void reboteX() {
        if (dirX == 10)
        {
            dirX = -10;
        }
        else {
            dirX = 10;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void reboteY() {
        if (dirY == 10)
        {
            dirY = -10;
        }
        else
        {
            dirY = 10;
        }
    }


}
