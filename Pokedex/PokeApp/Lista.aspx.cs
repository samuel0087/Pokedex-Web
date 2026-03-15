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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            if (!IsPostBack)
            {
                Session.Add("listaPokemons", negocio.listar());
            }

            dgvPokemon.DataSource = Session["listaPokemons"];
            dgvPokemon.DataBind();
        }

        protected void dgvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void dgvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemon.PageIndex = e.NewPageIndex;
            dgvPokemon.DataBind();
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 2) {
                string filtro = txtFiltro.Text.ToUpper();
                List<Pokemon> listaFiltrada = ((List<Pokemon>)Session["listaPokemons"]).FindAll(x => x.Nombre.ToUpper().Contains(filtro) || x.Tipo.Descripcion.ToUpper().Contains(filtro)|| x.Descripcion.ToUpper().Contains(filtro));
                dgvPokemon.DataSource = null;
                dgvPokemon.DataSource = listaFiltrada;
                dgvPokemon.DataBind();
            }
        }
    }
}