using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Propiedades básicas:
    -Ruta Imagen: Cadena, Consultable, Modificable
     
*/

namespace Ejercicio1Examen.Models.Entities
{
    public class Imagen
    {
        private String _rutaImagen;

        public Imagen()
        {
            _rutaImagen = "";
        }

        public Imagen(String rutaImagen)
        {
            _rutaImagen = rutaImagen;
        }


        public String RutaImagen
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





    }
}
