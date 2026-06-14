using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dominio;
using negocio;
using PokeApp_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokeApp_MVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: PokemonController
        public ActionResult Index(string filtro)
        {
            PokemonNegocio nPokemon = new PokemonNegocio();
            var pokemons = nPokemon.listar();

            if(!string.IsNullOrEmpty(filtro))
            {
                pokemons = pokemons.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
             }

            ViewBag.Filtro = filtro;

            return View(pokemons);
        }

        // GET: PokemonController/Details/5
        public ActionResult Details(int id)
        {
            PokemonNegocio nPokemon = new PokemonNegocio();
            dominio.Pokemon pokemon = nPokemon.getOne(id);
            return View(pokemon);
        }

        // GET: PokemonController/Create
        public ActionResult Create()
        {
            try
            {
                ElementoNegocio nElemento = new ElementoNegocio();
                ViewBag.Elemento = new SelectList(nElemento.listar(), "Id", "Descripcion");
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: PokemonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(dominio.Pokemon pokemon)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return View(pokemon);
                }

                PokemonNegocio nPokemon = new PokemonNegocio();
                pokemon.Tipo.Id = 1;
                pokemon.Debilidad.Id = 2;
                nPokemon.agregarPokemon(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PokemonNegocio nPokemon = new PokemonNegocio();
                ElementoNegocio nElemento = new ElementoNegocio();

                var pokemon = nPokemon.getOne(id);
                var listaElementos = nElemento.listar();

                ViewBag.Tipos = new SelectList(listaElementos, "Id", "Descripcion", pokemon.Tipo.Id);
                ViewBag.Debilidades = new SelectList(listaElementos, "Id", "Descripcion", pokemon.Debilidad.Id);

                return View(pokemon);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(dominio.Pokemon pokemon)
        {
            try
            {
                PokemonNegocio nPokemon = new PokemonNegocio();
                nPokemon.modificarPokemon(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Delete/5
        public ActionResult Delete(int id)
        {
            PokemonNegocio nPokemon = new PokemonNegocio();
            dominio.Pokemon pokemon = nPokemon.getOne(id);
            return View(pokemon);
        }

        // POST: PokemonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                PokemonNegocio nPokemon = new PokemonNegocio();
                nPokemon.eliminacionFisica(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
