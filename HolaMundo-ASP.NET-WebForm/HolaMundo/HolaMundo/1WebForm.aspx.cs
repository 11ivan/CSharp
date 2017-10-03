using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundo
{
    public partial class _1WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            borraErrores();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void borraErrores() {
            idErrorNombre.Text = "";
            idErrorApellido.Text = "";
            idGood.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviar(object sender, EventArgs e)
        {
            String nombre = this.txtNombre.Text;
            String apellido = this.txtApellidos.Text;

            if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(apellido))
            {
                idErrorNombre.Text = "Debe introducir el nombre";
                idErrorApellido.Text = "Debe introducir el apellido";
            }
            else if (String.IsNullOrWhiteSpace(nombre))
            {
                idErrorNombre.Text = "Debe introducir el nombre";
            }
            else if (String.IsNullOrWhiteSpace(apellido))
            {
                idErrorApellido.Text = "Debe introducir el apellido";  
            }
            else {
                idGood.Text = "OU YEAAAH!";
            }
        }
    }
}