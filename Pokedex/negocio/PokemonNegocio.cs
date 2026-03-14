using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> list = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            string query = @"SELECT p.Id, p.Numero, p.Nombre, p.Descripcion, p.UrlImagen, t.Id AS idTipo, t.Descripcion AS Tipo, d.Id As idDebilidad, d.Descripcion As Debilidad, p.Activo " +
                            "FROM POKEMONS p Inner Join ELEMENTOS t ON p.IdTipo = t.Id " +
                            "Inner Join ELEMENTOS d ON p.IdDebilidad = d.Id ";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector["Numero"] is DBNull ? 0 : (int)datos.Lector["Numero"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = datos.Lector["UrlImagen"] is DBNull ? "" : (string)datos.Lector["UrlImagen"];
                    aux.Estado = datos.Lector["Activo"] is DBNull ? false : (bool)datos.Lector["Activo"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = datos.Lector["idTipo"] is DBNull ? 0 : (int)datos.Lector["idTipo"];
                    aux.Tipo.Descripcion = datos.Lector["Tipo"] is DBNull ? "" : (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = datos.Lector["idDebilidad"] is DBNull ? 0 : (int)datos.Lector["idDebilidad"];
                    aux.Debilidad.Descripcion = datos.Lector["Debilidad"] is DBNull ? "" : (string)datos.Lector["Debilidad"];

                    list.Add(aux);

                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public Pokemon getOne(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = @"SELECT p.Id, p.Numero, p.Nombre, p.Descripcion, p.UrlImagen, t.Id AS idTipo, t.Descripcion AS Tipo, d.Id As idDebilidad, d.Descripcion As Debilidad, p.Activo " +
                            "FROM POKEMONS p Inner Join ELEMENTOS t ON p.IdTipo = t.Id " +
                            "Inner Join ELEMENTOS d ON p.IdDebilidad = d.Id " +
                            "Where p.Id = @id";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                Pokemon aux = new Pokemon();

                if (datos.Lector.Read())
                {
                    aux.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector["Numero"] is DBNull ? 0 : (int)datos.Lector["Numero"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = datos.Lector["UrlImagen"] is DBNull ? "" : (string)datos.Lector["UrlImagen"];
                    aux.Estado = datos.Lector["Activo"] is DBNull ? false : (bool)datos.Lector["Activo"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = datos.Lector["idTipo"] is DBNull ? 0 : (int)datos.Lector["idTipo"];
                    aux.Tipo.Descripcion = datos.Lector["Tipo"] is DBNull ? "" : (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = datos.Lector["idDebilidad"] is DBNull ? 0 : (int)datos.Lector["idDebilidad"];
                    aux.Debilidad.Descripcion = datos.Lector["Debilidad"] is DBNull ? "" : (string)datos.Lector["Debilidad"];
                }

                return aux;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregarPokemon(Pokemon pokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            String query = @"Insert Into POKEMONS (Numero, Nombre, Descripcion, UrlImagen, idTipo, idDebilidad, Activo) " +
                            "Values(@numero, @nombre, @descripcion,@imagen, @idTipo, @idDebilidad, 1)";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@numero", pokemon.Numero);
                datos.setearParametro("@nombre", pokemon.Nombre);
                datos.setearParametro("@descripcion", pokemon.Descripcion);
                datos.setearParametro("@imagen", pokemon.UrlImagen);
                datos.setearParametro("@idTipo", pokemon.Tipo.Id);
                datos.setearParametro("@idDebilidad", pokemon.Debilidad.Id);

                datos.ejecutarAccion();

            }
            catch (Exception e)
            {
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Boolean verificarPokemonByNumero(int numeroPokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "Select Numero From Pokemons Where Numero = @numero";
            Boolean result = false;

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@numero", numeroPokemon);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    //Capturar el id y devolver el true o false
                    int numeroBase = datos.Lector["Numero"] is DBNull ? 0 : (int)datos.Lector["numero"];

                    if (numeroBase == numeroPokemon)
                    {
                        result = true;
                    }
                }

                return result;

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

        public void modificarPokemon(Pokemon pokemon)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = @"Update Pokemons set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @imagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @idPokemon;";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@numero", pokemon.Numero);
                datos.setearParametro("@nombre", pokemon.Nombre);
                datos.setearParametro("@descripcion", pokemon.Descripcion);
                datos.setearParametro("@imagen", pokemon.UrlImagen);
                datos.setearParametro("@idTipo", pokemon.Tipo.Id);
                datos.setearParametro("@idDebilidad", pokemon.Debilidad.Id);
                datos.setearParametro("@idPokemon", pokemon.Id);

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

        public void eliminacionFisica(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "Delete From Pokemons Where Id = @idPokemon";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@idPokemon", id);

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

        public void eliminacionLogica(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "Update Pokemons Set Activo = 0 Where Id = @idPokemon";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@idPokemon", id);

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

        public void reactivarPokemon(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "Update Pokemons Set Activo = 1 Where Id = @idPokemon";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@idPokemon", id);

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

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pokemon> list = new List<Pokemon>();
            string query = @"SELECT p.Id, p.Numero, p.Nombre, p.Descripcion, p.UrlImagen, t.Id AS idTipo, t.Descripcion AS Tipo, d.Id As idDebilidad, d.Descripcion As Debilidad " +
                            "FROM POKEMONS p Inner Join ELEMENTOS t ON p.IdTipo = t.Id " +
                            "Inner Join ELEMENTOS d ON p.IdDebilidad = d.Id " +
                            "Where Activo = 1 And p." + campo;

            try
            {
                if (campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor que":
                            query += " < " + filtro;
                            break;

                        case "Menor que":
                            query += " > " + filtro;
                            break;

                        case "Igual que":
                            query += " = " + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            query += " Like '" + filtro + "%'";
                            break;

                        case "Termina con":
                            query += " Like '%" + filtro + "'";
                            break;

                        case "Contiene":
                            query += " Like '%" + filtro + "%'";
                            break;

                        default:
                            query += " Like '%%'";
                            break;
                    }
                }


                datos.setearConsulta(query);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = datos.Lector["Id"] is DBNull ? 0 : (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector["Numero"] is DBNull ? 0 : (int)datos.Lector["Numero"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = datos.Lector["UrlImagen"] is DBNull ? "" : (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = datos.Lector["idTipo"] is DBNull ? 0 : (int)datos.Lector["idTipo"];
                    aux.Tipo.Descripcion = datos.Lector["Tipo"] is DBNull ? "" : (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = datos.Lector["idDebilidad"] is DBNull ? 0 : (int)datos.Lector["idDebilidad"];
                    aux.Debilidad.Descripcion = datos.Lector["Debilidad"] is DBNull ? "" : (string)datos.Lector["Debilidad"];

                    list.Add(aux);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
