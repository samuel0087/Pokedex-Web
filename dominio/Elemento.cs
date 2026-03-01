using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elemento
    {
        public int Id { get; set; }
        public string  Descripcion { set; get; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
