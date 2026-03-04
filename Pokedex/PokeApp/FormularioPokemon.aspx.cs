using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeApp
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        private PokemonNegocio negocio = new PokemonNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ElementoNegocio eNegocio = new ElementoNegocio();
                cargarDdls(ddlTipo, eNegocio.listar());
                cargarDdls(ddlDebilidad, eNegocio.listar());

                if (Request.QueryString["id"] != null)
                {
                    cargarDatos(Request.QueryString["id"]);
                }
            }            
        }

        private void cargarDdls(DropDownList ddl, List<Elemento> lista)
        {
            ddl.DataSource = lista;
            ddl.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatos(string id)
        {
            Pokemon poke = negocio.getOne(int.Parse(id));

            txtId.Text = poke.Id.ToString();
            txtNombre.Text = poke.Nombre;
            txtNumero.Text = poke.Numero.ToString();
            txtDescripcion.Text = poke.Descripcion;
            ddlTipo.SelectedValue = poke.Tipo.Descripcion;
            ddlDebilidad.SelectedValue = poke.Debilidad.Descripcion;

        }
    }
}