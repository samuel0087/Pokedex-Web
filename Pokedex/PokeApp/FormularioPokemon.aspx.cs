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
        public bool ConfirmarEliminacion;

        private PokemonNegocio negocio = new PokemonNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminacion = false;

            if (!IsPostBack)
            {
                btnEliminar.Visible = false;
                ElementoNegocio eNegocio = new ElementoNegocio();
                cargarDdls(ddlTipo, eNegocio.listar());
                cargarDdls(ddlDebilidad, eNegocio.listar());

                if (Request.QueryString["id"] != null)
                {
                    cargarDatos(Request.QueryString["id"]);
                    btnEliminar.Visible = true;
                }
            }            
        }

        private void cargarDdls(DropDownList ddl, List<Elemento> lista)
        {
            ddl.DataSource = lista;
            ddl.DataTextField = "Descripcion";
            ddl.DataValueField = "Id";
            ddl.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio pNegocio = new PokemonNegocio();
            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagen.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);

                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    pNegocio.modificarPokemon(nuevo);
                }
                else
                {
                    pNegocio.agregarPokemon(nuevo);
                }

                    Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //Response.Redirect("Error.aspx", false);
            }

        }

        private void cargarDatos(string id)
        {
            Pokemon poke = negocio.getOne(int.Parse(id));

            txtId.Text = poke.Id.ToString();
            txtNombre.Text = poke.Nombre;
            txtNumero.Text = poke.Numero.ToString();
            txtDescripcion.Text = poke.Descripcion;
            ddlTipo.SelectedValue = poke.Tipo.Id.ToString();
            ddlDebilidad.SelectedValue = poke.Debilidad.Id.ToString();
            txtImagen.Text = poke.UrlImagen;
            imagenPokemon.ImageUrl = poke.UrlImagen;

        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imagenPokemon.ImageUrl = txtImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            PokemonNegocio pNegocio = new PokemonNegocio();
            pNegocio.eliminacionFisica(int.Parse(Request.QueryString["id"]));
            Response.Redirect("Default.aspx", false);
        }

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            PokemonNegocio pNegocio = new PokemonNegocio();
            pNegocio.eliminacionLogica(int.Parse(Request.QueryString["id"]));
            Response.Redirect("Default.aspx", false);
        }
    }
}