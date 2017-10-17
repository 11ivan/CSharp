using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _05_MVCListaPersonas.Models;

namespace _05_MVCListaPersonas.Models
{
    public class ListPersonas
    {
        private List<Persona> listaPersonas;
        
        public ListPersonas() {
            listaPersonas = new List<Persona>();
        }

        public Persona getPersona(int pos) {
            return listaPersonas.ElementAt(pos);         
             /* try
            {
                return listaPersonas.ElementAt(pos);
            }
            catch (ArgumentNullException argN) {
                argN.ToString();
            }
            catch (ArgumentOutOfRangeException argOut) {
                argOut.ToString();
            }*/
        }

        public void addPersona(Persona persona) {
            listaPersonas.Add(item: persona);
        }

        public void dropPersona(int pos) {
            listaPersonas.RemoveAt(pos);
        }

        public int size() {
            int size = listaPersonas.Count;            
            return size;
        }


    }
}