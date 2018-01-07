using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejas
{
    public class Carta
    {

#region Propiedades

        private string _rutaImagen;
        private int _numeroPareja;
        private Boolean _haSalido;

#endregion Propiedades


#region Contructores
        public Carta()
        {
            _rutaImagen = "";
            _numeroPareja = -1;
            _haSalido = false;
        }

        public Carta(string rutaImagen, int numeroPareja, Boolean haSalido)
        {
            _rutaImagen = rutaImagen;
            _numeroPareja = numeroPareja;
            _haSalido = haSalido;
        }
        /*public Carta(Object carta)
        {
            _rutaImagen = carta.RutaImagen;
            _numeroPareja = numeroPareja;
            _haSalido = haSalido;
        }*/


        #endregion Contructores


        #region Getters and Setters

        public string RutaImagen
        {
            get
            {
                return _rutaImagen;
            }
            set
            {
                _rutaImagen = value;
            }
        }

        public int NumeroPareja
        {
            get
            {
                return _numeroPareja;
            }
            set
            {
                _numeroPareja = value;
            }
        }

        public Boolean HaSalido
        {
            get
            {
                return _haSalido;
            }
            set
            {
                _haSalido = value;
            }
        }


#endregion Getters and Setter








    }
}
