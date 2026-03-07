using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace PokeApp
{
    public partial class DropDownListEnlazados : System.Web.UI.Page
    {
        public ElementoNegocio eNegocio = new ElementoNegocio();
        public PokemonNegocio pNegocio = new PokemonNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtengo los datos de pokemons y los guardo en la session
                Session["listaPokemons"] = pNegocio.listar();

                List<Elemento> listaElementos = eNegocio.listar();

                //Configuro desplegables desde db con id y descripcion
                ddlTipo.DataSource = listaElementos;
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataBind();
            }

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlTipo.SelectedItem.Value);
            ddlPokemonsFiltrados.DataSource = ((List<Pokemon>)Session["listaPokemons"]).FindAll(x => x.Tipo.Id == id);
            ddlPokemonsFiltrados.DataTextField = "Nombre";
            ddlPokemonsFiltrados.DataBind();

        }
    }
}