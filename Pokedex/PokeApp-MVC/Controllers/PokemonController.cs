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
        public ActionResult Index()
        {
            PokemonNegocio nPokemon = new PokemonNegocio();
            return View(nPokemon.listar());
        }

        // GET: PokemonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PokemonController/Create
        public ActionResult Create()
        {
            try
            {
                ElementoNegocio nElemento = new ElementoNegocio();
                ViewBag.Elemetos = new SelectList(nElemento.listar(), "Id", "Descripcion");
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
            return View();
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: PokemonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
