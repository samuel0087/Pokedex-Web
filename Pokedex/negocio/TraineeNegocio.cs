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
			string query = "SELECT Id, Email, Pass,Nombre, Apellido, ImagenPerfil, Admin FROM USERS WHERE Email = @email AND Pass = @pass";

			try
			{
				datos.setearConsulta(query);
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Password);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					usuario.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
					usuario.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
					usuario.Apellido = datos.Lector["Apellido"] is DBNull ? "" : (string)datos.Lector["Apellido"];
					usuario.ImagenPerfil = datos.Lector["ImagenPerfil"] is DBNull ? "" : (string)datos.Lector["ImagenPerfil"];
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

		public void actualizar(Trainee user)
		{
			AccesoDatos datos = new AccesoDatos();
			string query = "UPDATE USERS SET Nombre = @nombre, Apellido = @apellido, ImagenPerfil = @img WHERE Id = @id"; ;
			try
			{
				datos.setearConsulta(query);
				datos.setearParametro("@id", user.Id);
				datos.setearParametro("@nombre", user.Nombre);
				datos.setearParametro("@apellido", user.Apellido);
				datos.setearParametro("@img", user.ImagenPerfil != "" ? user.ImagenPerfil : "");
				datos.ejecutarAccion();
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
