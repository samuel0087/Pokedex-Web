using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio tNegocio = new TraineeNegocio();

            try
            {
                trainee.Email = txtEmail.Text;
                trainee.Password = txtPass.Text;

                if(tNegocio.Login(trainee) )
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("Lista.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario y/o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false );
                }

            }
            catch (Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }
    }
}