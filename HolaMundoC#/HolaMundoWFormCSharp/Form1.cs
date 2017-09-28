using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolaMundoWFormCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /*
         Propósito:
         Prototipo:
         Entradas:
         Salidas:
         Precondiciones:
         Postcondiciones:         
        */
        /// <summary>
        /// Comprueba que un nombre estaba no esté vacío.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            if (String.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe introducir el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Debe introducir el nombre");
            }
            else {
                MessageBox.Show($"Hola {nombre}", "Muy Bien");
            }
        }

    }
}
