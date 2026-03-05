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
    public partial class EjemploDropDowns : System.Web.UI.Page
    {
        PokemonNegocio negocio = new PokemonNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlPokemons.DataSource = negocio.listar();
            ddlPokemons.DataTextField = "Nombre";
            ddlPokemons.DataValueField = "Id";
            ddlPokemons.DataBind();


        }
    }
}