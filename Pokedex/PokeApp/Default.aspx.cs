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
    public partial class _Default : Page
    {
        public List<Pokemon> listaPokemon;
        public void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();

            if (!IsPostBack)
            {
                repRepeater.DataSource = listaPokemon;
                repRepeater.DataBind();
            }           

        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}