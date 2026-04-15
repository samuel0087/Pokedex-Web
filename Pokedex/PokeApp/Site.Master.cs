using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeApp
{
    public partial class SiteMaster : MasterPage
    {
        public Boolean sesionActiva { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Seguridad.sessionActiva(Session["trainee"]))
            {
                sesionActiva = true;
            }

            if (!(Page is Login) && !(Page is _Default) && !(Page is Registro) && !(Page is Error))
            {
                if (!sesionActiva)
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}