using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
		public int InsertarNuevo(Trainee usuario)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedimiento("InsertarNuevo");
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Password);
				return datos.ejecutarAccionScalar();
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
