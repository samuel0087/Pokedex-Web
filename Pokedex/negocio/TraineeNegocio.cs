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

		public bool Login(Trainee usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			string query = "SELECT Id, Email, Pass, Admin FROM USERS WHERE Email = @email AND Pass = @pass";

			try
			{
				datos.setearConsulta(query);
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Password);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					usuario.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
					usuario.Admin = datos.Lector["Admin"] is DBNull ? false : (bool)datos.Lector["Admin"];
					return true;
				}

				return false;
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
