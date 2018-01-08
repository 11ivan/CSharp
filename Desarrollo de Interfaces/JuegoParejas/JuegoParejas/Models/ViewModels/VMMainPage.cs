using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

/*
Propiedades: 
    Tiempo de juego: Cadena, Consultable, Modificable

 
*/

namespace JuegoParejas.ViewModels
{
    public class VMMainPage:clsVMBase
    {

#region Propiedades

        private DispatcherTimer timer;
        private string tiempoJuego;
        private TimeSpan transcurrido;
        private int cartasLevantadas;
        //private string[] listaImagenes;
        private Carta[] listaCartas;//Este array se tratará en paralelo con las imagenes de la vista
        private Image[] listaCartasLevantadas;//Este array de imagenes se usará para guardar las imagenes de la vista cada vez que se pulse una, para después poder voltearlas en caso de fallo o reinicio de partida
        private int[] posicionUltimasDosLevantadas;
        private int aciertos;
        private DispatcherTimer timerTapaCartas;
        private Boolean haPausado;
        private AppBarButton buttonPlayPause;
        private Carta[] arrayCartas;//De este array se obtendran las cartas para "colocarlas" en la partida
        private Boolean noPlayPause;
        private BitmapImage imagenPorDefecto;

        #endregion Propiedades


        public VMMainPage()
        {
            transcurrido = new TimeSpan(0, 0, 0);
            tiempoJuego = transcurrido.ToString().Substring(0,8);
            cartasLevantadas = 0;
            //listaImagenes = new string[12];
            arrayCartas = new Carta[12];
            listaCartas = new Carta[12];
            listaCartasLevantadas = new Image[12];
            posicionUltimasDosLevantadas = new int[2];
            aciertos = 0;
            timerTapaCartas = new DispatcherTimer();
            timerTapaCartas.Interval = TimeSpan.FromSeconds(1);
            timerTapaCartas.Tick += TimerTapaCartas_Tick;
            haPausado = false;
            buttonPlayPause = new AppBarButton();
            noPlayPause = false;
            preparaImagenes();
            imagenPorDefecto = new BitmapImage(new Uri("ms-appx:///assets/Images/reverso.jpg"));

            colocaImagenes();
            startGameTimer();
        }


#region Getters and Setters
        public string TiempoJuego
        {
            get
            {
                return tiempoJuego;
            }
            set
            {
                tiempoJuego = value;
                NotifyPropertyChanged("TiempoJuego");
            }
        }


#endregion Getters and Setters


#region Metodos 

        /// <summary>
        /// Inicia el dispatchertimer que controla el tiempo de juego
        /// </summary>
        public void startGameTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timerTick;
            timer.Start();
        }

        /// <summary>
        /// Prepara las Cartas con sus respectivas parejas que se usarán para el juego
        /// </summary>
        public void preparaImagenes()
        {
            arrayCartas[0] = new Carta("ms-appx:///assets/Images/armadaryl.jpg", 1, false);
            arrayCartas[1] = new Carta("ms-appx:///assets/Images/daryl.jpg", 1, false);

            arrayCartas[2] = new Carta("ms-appx:///assets/Images/armamichonne.jpg", 2, false);
            arrayCartas[3] = new Carta("ms-appx:///assets/Images/michonne.jpg", 2, false);

            arrayCartas[4] = new Carta("ms-appx:///assets/Images/armanigan.jpg", 3, false);
            arrayCartas[5] = new Carta("ms-appx:///assets/Images/nigan.jpg", 3, false);

            arrayCartas[6] = new Carta("ms-appx:///assets/Images/armarick.jpg", 4, false);
            arrayCartas[7] = new Carta("ms-appx:///assets/Images/rick.jpg", 4, false);
        
            arrayCartas[8] = new Carta("ms-appx:///assets/Images/armaezequiel.jpg", 5, false);
            arrayCartas[9] = new Carta("ms-appx:///assets/Images/ezequiel.jpg", 5, false);
        
            arrayCartas[10] = new Carta("ms-appx:///assets/Images/morgan.jpg", 6, false);
            arrayCartas[11] = new Carta("ms-appx:///assets/Images/armamorgan.jpg", 6, false);
        }

        /// <summary>
        /// Cambia el tiempo marcado en la vista en un segundo más
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTick(object sender, object e)
        {
            //Aumentamos el tiempo transcurrido en un segundo
            transcurrido = new TimeSpan(transcurrido.Hours,transcurrido.Minutes,transcurrido.Seconds+1);

            //Se lo asignamos a TiempoJuego que es el encargado de mostrarlo en la vista
            TiempoJuego = transcurrido.ToString().Substring(0, 8);
        }


        /// <summary>
        /// Pausa o reanuda el juego
        /// </summary>
        public void ClickPausePlay(object sender, RoutedEventArgs e)
        {
            buttonPlayPause = (AppBarButton)sender;


           if (noPlayPause == false)
            {

                if (buttonPlayPause.Label.Equals("Pause"))
                {
                    //Ponemos haPausado a true
                    haPausado = true;

                    //Detenemos el tiempo de juego
                    timer.Stop();

                    //guardamos el tiempo para cuando reanude no de el salto
                    //actual = DateTime.Now;

                    //Cambiamos el label al botón
                    buttonPlayPause.Label = "Play";

                    //Cambiamos el icono al boton
                    buttonPlayPause.Icon = new SymbolIcon(Symbol.Play);
                }
                else
                {
                    //Ponemos haPausado a false
                    haPausado = false;

                    //Reanudamos el tiempo de juego
                    timer.Start();

                    //Cambiamos el label al botón
                    buttonPlayPause.Label = "Pause";

                    //Cambiamos el icono al boton
                    buttonPlayPause.Icon = new SymbolIcon(Symbol.Pause);
                }
            }
        }

        /// <summary>
        /// Cuando se hace clic en el boton restart de la vista llama al metodo preguntarNuevaPartida
        /// con el motivo 1 el cual equivale a reinicio
        /// </summary>
        public void ClickRestart()
        {
            preguntarNuevaPartida(1);
        }

        /// <summary>
        /// Coloca las rutas de las imagenes de forma aleatoria en el array (listaImagenes)
        /// para usarlo en paralelo con las imagenes de la vista
        /// </summary>
        /*public void colocaImagenes()
        {
            Random random = new Random();
            int imagenGenerada = 0;
            string[][] rutasImagenes=null;
            rutasImagenes[0][0] = "ms-appx:///assets/Images/armadaryl.jpg";
            rutasImagenes[1][0] = "ms-appx:///assets/Images/daryl.jpg";
            rutasImagenes[2][0] = "ms-appx:///assets/Images/armamichonne.jpg";
            rutasImagenes[3][0] = "ms-appx:///assets/Images/michonne.jpg";
            rutasImagenes[4][0] = "ms-appx:///assets/Images/armanigan.jpg";
            rutasImagenes[5][0] = "ms-appx:///assets/Images/nigan.jpg";
            rutasImagenes[6][0] = "ms-appx:///assets/Images/armarick.jpg";
            rutasImagenes[7][0] = "ms-appx:///assets/Images/rick.jpg";
            rutasImagenes[8][0] = "ms-appx:///assets/Images/armaezequiel.jpg";
            rutasImagenes[9][0] = "ms-appx:///assets/Images/ezequiel.jpg";
            rutasImagenes[10][0] = "ms-appx:///assets/Images/morgan.jpg";
            rutasImagenes[11][0] = "ms-appx:///assets/Images/armamorgan.jpg";
            Boolean sal = false;

            for (int i=0;i<11;i++)
            {
                //Generamos una ruta de imagen aleatoria
                do
                {
                    imagenGenerada = random.Next(0, 11);
                } while (rutasImagenes[imagenGenerada][1] != null);

                //Marcamos la imagen como que ya ha salido
                rutasImagenes[imagenGenerada][1] = "Ha salido";

                //Colocamos la ruta aleatoria en la lista de imagenes
                listaImagenes[i] = rutasImagenes[imagenGenerada][0];
            }

            //En la última posición pondremos la imagen que quede para ahorrar iteraciones, ya que será más fácil buscarla 
            //que generar aleatoriamente hasta que salga

            //Intentar con exprexion lambda
            for (int i=0;i<rutasImagenes.GetLength(0) && !sal;i++)
            {
                if (rutasImagenes[i][1]==null)
                {
                    listaImagenes[11] = rutasImagenes[i][0];
                    sal = true;
                }
            }
        }*/

        /// <summary>
        /// Coloca las Cartas de arrayCartas de forma aleatoria en el array (listaCartas)
        /// para usarlo en paralelo con las imagenes de la vista
        /// </summary>
        public void colocaImagenes()
        {
            Random random = new Random();
            int cartaGenerada = 0;
            Boolean sal = false;

            for (int i = 0; i < 11; i++)
            {
                //Generamos una Carta aleatoria mientras la genereada ya haya salido
                do
                {
                    cartaGenerada = random.Next(0, 11);
                } while (arrayCartas[cartaGenerada].HaSalido == true);

                //Marcamos la Carta como que ya ha salido
                arrayCartas[cartaGenerada].HaSalido = true;

                //Colocamos la Carta aleatoria en la lista de Cartas que se trata en paralelo con la vista
                listaCartas[i] = arrayCartas[cartaGenerada];
            }

            //En la última posición pondremos la imagen que quede para ahorrar iteraciones, ya que será más fácil buscarla 
            //que generar aleatoriamente hasta que salga

            //Intentar con exprexion lambda
            /*for (int i = 0; i < arrayCartas.Length && !sal; i++)
            {
                if (arrayCartas[i].HaSalido == false)
                {
                    listaCartas[11] = arrayCartas[i];
                    sal = true;
                }
            }*/

            var x = from item in arrayCartas where item.HaSalido == false select item;
            Object carta = x;
            listaCartas[11] = carta as Carta; 
        }

        /// <summary>
        /// Cambia una imagen de la vista por la que coincida en la posicion
        /// del array (listaImagenes), éste método sólo funcionará si se han levantado menos de 2 cartas y
        /// la lista de cartas levantadas no contiene ya la imagen pulsada y no se haya pausado la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*public void levantaCarta(object sender, RoutedEventArgs e)
        {
            Image imagen = (Image)sender;
            BitmapImage bitMap = new BitmapImage();
            string rutaImagen = "";

            //Si se han levantado menos de dos cartas, la lista de cartas levantadas no contiene ya la imagen pulsada y no se ha pausado la partida
            if (cartasLevantadas < 2 && !listaCartasLevantadas.Contains(imagen) && haPausado==false)
            {            
                switch (imagen.Name)
                {
                    case "img1":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 0;
                        break;

                    case "img2":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 1;
                        break;

                    case "img3":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 2;
                        break;

                    case "img4":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 3;
                        break;

                    case "img5":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 4;
                        break;

                    case "img6":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 5;
                        break;

                    case "img7":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 6;
                        break;
                    
                    case "img8":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 7;
                        break;

                    case "img9":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 8;
                        break;

                    case "img10":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 9;
                        break;

                    case "img11":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 10;
                        break;

                    case "img12":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 11;
                        break;
                }
                //Conseguimos la ruta de la imagen
                rutaImagen = listaImagenes[posicionUltimasDosLevantadas[cartasLevantadas]];

                //Cambiamos el nombre a la imagen para comprobar si las dos levantadas son pareja     
                imagen.Name = rutaImagen.Substring(25, rutaImagen.Length - 25);

                //Cambiamos la imagen
                bitMap.UriSource = new Uri(rutaImagen);
                imagen.Source = bitMap;

                //Guardamos la carta levantada para el futuro volteo por fallo o nueva partida              
                listaCartasLevantadas[posicionUltimasDosLevantadas[cartasLevantadas]] = imagen;

                //Aumentamos el contador de cartas levantadas
                cartasLevantadas++;
              
                //Si se han levantado dos cartas hay que comprobar si ha acertado
                if (cartasLevantadas==2)
                {
                    compruebaAcierto();
                }             
            }//fin si
        }*/

        /// <summary>
        /// Cambia una imagen de la vista por la que coincida en la posicion
        /// del array (listaCartas), éste método sólo funcionará si se han levantado menos de 2 cartas y
        /// la lista de cartas levantadas no contiene ya la imagen pulsada y no se haya pausado la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void levantaCarta(object sender, RoutedEventArgs e)
        {
            Image imagen = (Image)sender;
            BitmapImage bitMap = new BitmapImage();
            string rutaImagen = "";

            //Si se han levantado menos de dos cartas, la lista de cartas levantadas no contiene ya la imagen pulsada y no se ha pausado la partida
            if (cartasLevantadas < 2 && !listaCartasLevantadas.Contains(imagen) && haPausado == false)
            {
                switch (imagen.Name)
                {
                    case "img1":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 0;
                        break;

                    case "img2":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 1;
                        break;

                    case "img3":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 2;
                        break;

                    case "img4":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 3;
                        break;

                    case "img5":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 4;
                        break;

                    case "img6":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 5;
                        break;

                    case "img7":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 6;
                        break;

                    case "img8":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 7;
                        break;

                    case "img9":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 8;
                        break;

                    case "img10":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 9;
                        break;

                    case "img11":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 10;
                        break;

                    case "img12":
                        //Guardamos la posicion de la carta levantada
                        posicionUltimasDosLevantadas[cartasLevantadas] = 11;
                        break;
                }
                //Conseguimos la ruta de la imagen tirando del array relleno con las cartas aleatorias
                rutaImagen = listaCartas[posicionUltimasDosLevantadas[cartasLevantadas]].RutaImagen;

                //Cambiamos la imagen
                bitMap.UriSource = new Uri(rutaImagen);
                imagen.Source = bitMap;

                //Guardamos la carta levantada para el futuro volteo por fallo o nueva partida              
                listaCartasLevantadas[posicionUltimasDosLevantadas[cartasLevantadas]] = imagen;

                //Aumentamos el contador de cartas levantadas
                cartasLevantadas++;

                //Si se han levantado dos cartas hay que comprobar si ha acertado
                if (cartasLevantadas == 2)
                {
                    compruebaAcierto();
                }
            }//fin si
        }

        /// <summary>
        /// Cuando se han levantado dos cartas, éste método comprueba si el nombre de las imagenes
        /// son iguales para identificarlas como pareja
        /// </summary>
        /*public void compruebaAcierto()
        {              
            string name1 = listaCartasLevantadas.ElementAt(posicionUltimasDosLevantadas[0]).Name;
            string name2 = listaCartasLevantadas.ElementAt(posicionUltimasDosLevantadas[1]).Name;
            Boolean acierto = false;
            string nombreSinArma = "";
            
            //Si un nombre contiene arma y el otro no comprobaremos si son pareja sino habra fallado
            if (name1.Contains("arma") && !name2.Contains("arma") || !name1.Contains("arma") && name2.Contains("arma"))
            {              
                //Si el name1 es el que contiene arma
                if (name1.Contains("arma"))
                {
                    nombreSinArma = name1.Remove(0, 4);
                    //Si quitandole a name1 (arma-) es igual que name2 es que ha acertado
                    if (nombreSinArma.Equals(name2))
                    {
                        acierto = true;
                    }
                }//Fin si
                else//Sino es que lo contiene name2
                {
                    nombreSinArma = name2.Remove(0, 4);
                    //Si quitandole a name2 (arma-) es igual que name1 es que ha acertado
                    if (nombreSinArma.Equals(name1))
                    {
                        acierto = true;
                    }
                }//Fin sino              
            }//Fin si

            //Si ha acertado
            if (acierto)
            {
                //Aumentar contador de aciertos
                aciertos++;

                //Resetear contador de cartas levantadas
                cartasLevantadas = 0;

                //Si la cantidad de aciertos es 6 mostramos mensaje de Ganador
                //con el tiempo que ha tardado y preguntamos si vuelve a jugar
                if (aciertos==6) {
                    //Llamada a método mensaje ganador
                    //mensajeGanador();

                    //Hay que hacerlo de modo que el programa no intente abrir los dos content dialog al mismo tiempo 
                    //así que el método preguntarNuevaPartida debe esperar a que se cierre el contentDialog del método mensajeGanador
                    //O que el metodo de preguntarNuevaPartida sepa a que se debe la pregunta y gestione el mensaje mostrado

                    //Llamada a método para preguntar si vuelve a jugar
                    preguntarNuevaPartida(0);
                }
            }
            else //Sino ha acertado
            {           
                //Llamada a método para tapar cartas
                tapaCartas();
            }
        }*/

        /// <summary>
        /// Cuando se han levantado dos cartas, éste método comprueba si el nombre de las imagenes
        /// son iguales para identificarlas como pareja
        /// </summary>
        public void compruebaAcierto()
        {
            int numeroPareja1 = listaCartas[posicionUltimasDosLevantadas[0]].NumeroPareja;
            int numeroPareja2 = listaCartas[posicionUltimasDosLevantadas[1]].NumeroPareja;

            //Si el numero de pareja de la primera carta y la segunda son iguales ha acertado
            if (numeroPareja1==numeroPareja2)
            {
                //Aumentar contador de aciertos
                aciertos++;

                //Resetear contador de cartas levantadas
                cartasLevantadas = 0;

                //Si la cantidad de aciertos es 6 mostramos mensaje de Ganador
                //con el tiempo que ha tardado y preguntamos si vuelve a jugar
                if (aciertos == 6)
                {
                    //Llamada a método mensaje ganador
                    //mensajeGanador();

                    //Hay que hacerlo de modo que el programa no intente abrir los dos content dialog al mismo tiempo 
                    //así que el método preguntarNuevaPartida debe esperar a que se cierre el contentDialog del método mensajeGanador

                    //O que el metodo de preguntarNuevaPartida sepa a que se debe la pregunta y gestione el mensaje mostrado

                    //Llamada a método para preguntar si vuelve a jugar
                    preguntarNuevaPartida(0);
                }
            }
            else //Sino ha acertado
            {
                //Llamada a método para tapar cartas
                tapaCartas();
            }           
        }

        /// <summary>
        /// Inicia el DistacherTimer que se encarga de tapar las cartas
        /// </summary>
        public void tapaCartas()
        {           
            timerTapaCartas.Start();
        }

        /// <summary>
        /// Pasado un segundo éste método pone la imagen por defecto en las últimas dos cartas levantadas,
        /// pone el nombre que las imagenes tenían, quita las imagenes de la lista de cartas levantadas,
        /// pone el contador de cartas levantadas a 0 y para el timer encargado de tapar las cartas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void TimerTapaCartas_Tick(object sender, object e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri("ms-appx:///assets/Images/reverso.jpg");

            //Ponemos la imagen por defecto
            listaCartasLevantadas[posicionUltimasDosLevantadas[0]].Source = bitmap;
            listaCartasLevantadas[posicionUltimasDosLevantadas[1]].Source = bitmap;

            //Ponemos el nombre que tenian las imagenes
            listaCartasLevantadas[posicionUltimasDosLevantadas[0]].Name = "img" + (posicionUltimasDosLevantadas[0] + 1);
            listaCartasLevantadas[posicionUltimasDosLevantadas[1]].Name = "img" + (posicionUltimasDosLevantadas[1] + 1);

            //Quitamos las imagenes de listaCartasLevantadas
            listaCartasLevantadas[posicionUltimasDosLevantadas[0]] = null;
            listaCartasLevantadas[posicionUltimasDosLevantadas[1]] = null;

            //Resetear contador de cartas levantadas
            cartasLevantadas = 0;

            //Detenemos el timer que gestiona el tiempo en tapar las cartas
            timerTapaCartas.Stop();
        }*/

        /// <summary>
        /// Pasado un segundo éste método pone la imagen por defecto en las últimas dos cartas levantadas,
        /// quita las imagenes de la lista de cartas levantadas, pone el contador de cartas levantadas a 0 y para el timer encargado de tapar las cartas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTapaCartas_Tick(object sender, object e)
        {
            //Ponemos la imagen por defecto
            listaCartasLevantadas[posicionUltimasDosLevantadas[0]].Source = imagenPorDefecto;
            listaCartasLevantadas[posicionUltimasDosLevantadas[1]].Source = imagenPorDefecto;

            //Quitamos las imagenes de listaCartasLevantadas
            listaCartasLevantadas[posicionUltimasDosLevantadas[0]] = null;
            listaCartasLevantadas[posicionUltimasDosLevantadas[1]] = null;

            //Resetear contador de cartas levantadas
            cartasLevantadas = 0;

            //Detenemos el timer que gestiona el tiempo en tapar las cartas
            timerTapaCartas.Stop();
        }

        /// <summary>
        /// Método asíncrono que se encarga de mostrar al usuario un mensaje por 
        /// ganar la partida mostrando también el tiempo que ha tardado
        /// </summary>
        public async void mensajeGanador()
        {
            //Detenemos el timer que controla el tiempo de juego
            timer.Stop();

            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Enhorabuena!!";
            dialog.Content = "Ha ganado la partida, su tiempo ha sido "+tiempoJuego;
            dialog.PrimaryButtonText = "Ok";           

            await dialog.ShowAsync();           
        }

        /// <summary>      
        /// Método asíncrono que se encarga de preguntar al usuario si desea iniciar una nueva partida,
        /// pudiendo ser por haber ganado o por reinicio de partida
        /// </summary>
        /// <param name="motivo">Unentero que será 0 si el motivo es por haber ganado la partida y 1 por reinicio de partida</param>
        public async void preguntarNuevaPartida(int motivo)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "No";

            //Paramos el timer que controla el tiempo de juego
            timer.Stop();

            //Si el motivo es por reinicio de partida 
            if (motivo==1)
            {               
                dialog.Title = "Reinicio";
                dialog.Content = "¿Quiere reiniciar la partida?";
            }
            else
            {
                dialog.Title = "Enhorabuena!!";
                dialog.Content = "Ha ganado la partida, su tiempo ha sido " + tiempoJuego+"\n¿Comenzar nueva partida?";                   
            }

            //Mostramos cuadro de dialogo
            ContentDialogResult result = await dialog.ShowAsync();

            if (result==ContentDialogResult.Primary)
            {
                if (noPlayPause == true)
                {
                    noPlayPause = false;
                }
                //Llamada a método para reiniciar partida
                resetGame();
            }else
            {
                //Si el motivo fue por reinicio y decide no reiniciar
                if (motivo == 1)
                {
                    //Volvemos a iniciar el timer que controla el tiempo de juego
                    timer.Start();
                }
                else
                {
                    noPlayPause = true;
                }
            }
        }

        /// <summary>
        /// Reinicia la partida
        /// </summary>
        /*public void resetGame()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri("ms-appx:///assets/Images/reverso.jpg");

            for (int i=0;i<listaCartasLevantadas.Length;i++)
            {
                if (listaCartasLevantadas[i]!=null)
                {
                    //Devolvemos el nombre que tenían las cartas
                    listaCartasLevantadas[i].Name = "img" + (i + 1);

                    //Ponemos la imagen por defecto
                    listaCartasLevantadas[i].Source = bitmap;

                    //Quitamos la carta de nuestra lista de cartas levantadas
                    listaCartasLevantadas[i] = null;
                }
            }

            //Ponemos el contador de cartas levantadas a 0
            cartasLevantadas = 0;//No es necesario ya que se resetea en cada acierto o fallo
                                 //Sí es necesario ya que puede venir del reinicio de partida con una sola carta levantada

            //Ponemos el contador de aciertos a 0
            aciertos = 0;

            //Desmarcamos las posiciones de las dos ultimas cartas levantadas
            posicionUltimasDosLevantadas[0] = 0;
            posicionUltimasDosLevantadas[1] = 0;

            //Volvemo a colocar las cartas
            colocaImagenes();

            //Reiniciamos el timer del juego
            startGameTimer();

            //Reiniciamos el tiempo trancurrido
            transcurrido = new TimeSpan(0, 0, 0);

            //Reiniciamos el tiempo mostrado en la vista
            TiempoJuego = transcurrido.ToString().Substring(0,8);

            //Hay que comprobar si hay que volver a poner el icono en pause****
            if (haPausado)
            {
                haPausado = false;

                //Cambiamos el label al botón
                buttonPlayPause.Label = "Pause";

                //Cambiamos el icono al boton
                buttonPlayPause.Icon = new SymbolIcon(Symbol.Pause);
            }
        }*/

        /// <summary>
        /// Reinicia la partida
        /// </summary>
        public void resetGame()
        {
            //Reseteamos la lista de cartas levantadas
            for (int i = 0; i < listaCartasLevantadas.Length; i++)
            {
                //Si la carta se levanto
                if (listaCartasLevantadas[i] != null)
                {
                    //Ponemos la imagen por defecto
                    listaCartasLevantadas[i].Source = imagenPorDefecto;

                    //Quitamos la carta de nuestra lista de cartas levantadas
                    listaCartasLevantadas[i] = null;
                }
                //Aprovecho el bucle para resetear el array de cartas del que tiramos para colocarlas en la vista a que el atributo HaSalido de cada carta esta a True
                arrayCartas[i].HaSalido = false;
            }

            //Ponemos el contador de cartas levantadas a 0
            cartasLevantadas = 0;//No es necesario ya que se resetea en cada acierto o fallo
                                 //Sí es necesario ya que puede venir del reinicio de partida con una sola carta levantada

            //Ponemos el contador de aciertos a 0
            aciertos = 0;

            //Desmarcamos las posiciones de las dos ultimas cartas levantadas
            posicionUltimasDosLevantadas[0] = 0;
            posicionUltimasDosLevantadas[1] = 0;

            //Volvemo a colocar las cartas
            colocaImagenes();

            //Reiniciamos el timer del juego
            startGameTimer();

            //Reiniciamos el tiempo trancurrido
            transcurrido = new TimeSpan(0, 0, 0);

            //Reiniciamos el tiempo mostrado en la vista
            TiempoJuego = transcurrido.ToString().Substring(0, 8);

            //Hay que comprobar si hay que volver a poner el icono en pause****
            if (haPausado)
            {
                haPausado = false;

                //Cambiamos el label al botón
                buttonPlayPause.Label = "Pause";

                //Cambiamos el icono al boton
                buttonPlayPause.Icon = new SymbolIcon(Symbol.Pause);
            }
        }

#endregion Metodos



    }
}
