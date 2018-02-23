using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PersonajeConTransformacionesYHabilidades:Personaje
    {

        public List<Transformacion> listaTranformaciones { get; set; }
        public List<Habilidad> listaHabilidades { get; set; }

        public PersonajeConTransformacionesYHabilidades():base()
        {
            listaTranformaciones = new List<Transformacion>();
            listaHabilidades = new List<Habilidad>();
        }

    }
}
