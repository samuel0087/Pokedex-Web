using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        public int Id {  get; set; }
        [DisplayName("Número")]
        public int Numero { set; get; }
        public string Nombre { set; get; }
        [DisplayName("Descripción")]
        public string Descripcion { set; get; }
        public string UrlImagen { set; get; }
        public Elemento Tipo { set; get; }
        public Elemento Debilidad { set; get; }
        public bool Estado { set; get; }

    }
}
