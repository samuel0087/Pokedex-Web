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
    public partial class Perfil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Trainee user = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;

                if(user != null)
                {
                    imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];

                

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    string nombreImagen = "Perfil-" + user.Id + ".jpg";
                    txtImagen.PostedFile.SaveAs(ruta + nombreImagen);
                    user.ImagenPerfil = nombreImagen;
                }

                negocio.actualizar(user);
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