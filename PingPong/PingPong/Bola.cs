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

    private static int posX;
    private static int posY;
    private static int size;
    private static Ellipse ellip;
    private static int speedMove;


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
        speedMove = 5;
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
    public void move() {
        posX += speedMove;
        posY += speedMove;
        Canvas.SetTop(ellip, posX);
        Canvas.SetLeft(ellip, posY);
    }

    public void tomaPosicion() {
        Canvas.SetTop(ellip, posX);
        Canvas.SetLeft(ellip, posY);
    }

}
