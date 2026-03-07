using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeApp
{
    public partial class UpdatePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblNombre.Text = txtNombre.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblNombre.Text = txtNombre.Text;
        }
    }
}