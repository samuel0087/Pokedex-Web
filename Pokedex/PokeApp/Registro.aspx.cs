using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PokeApp
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio negocio = new TraineeNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                user.Id = negocio.InsertarNuevo(user);

                emailService.ArmarCorreo(user.Email, "Bienvenido maestro pokemon", "Hola, ya eres parte de nuestra comunidad pokemon");
                emailService.enviarEmail();

                Session.Add("trainee", user);

                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}