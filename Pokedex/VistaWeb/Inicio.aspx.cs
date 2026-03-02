using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace VistaWeb
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public List<Pokemon> listaPokemon;

        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listaPokemon;

        }
    }
}