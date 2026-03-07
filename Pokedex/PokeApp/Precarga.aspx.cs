using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokeApp
{
    public partial class Precarga : System.Web.UI.Page
    {
        public string urlImagen {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            urlImagen = "https://cdn-icons-png.flaticon.com/512/12048/12048902.png";
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            urlImagen = txtImagen.Text;
        }
    }
}