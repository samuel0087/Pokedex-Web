using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>();
            string query = "Select Id, Descripcion From Elementos";
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
                    aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
