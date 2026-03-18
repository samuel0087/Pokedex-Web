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
        public bool FiltroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                Session.Add("listaPokemons", negocio.listar());
                dgvPokemon.DataSource = Session["listaPokemons"];
                dgvPokemon.DataBind();
            }

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
            else
            {
                dgvPokemon.DataSource = (List<Pokemon>)Session["listaPokemons"];
                dgvPokemon.DataBind();
            }
 
        }
        public void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
            btnFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = ddlCampo.Items.FindByText("Seleccione una opcion");

            if (item != null)
            {
                ddlCampo.Items.Remove(item);
            }

            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Numero")
            {
                ddlCriterio.Items.Add("Mayor que");
                ddlCriterio.Items.Add("Menor que");
                ddlCriterio.Items.Add("Igual que");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemon.DataSource = null;
            List<Pokemon> filtrada = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text, ddlEstado.SelectedItem.ToString());
            dgvPokemon.DataSource = filtrada;
            dgvPokemon.DataBind();
        }
    }
}