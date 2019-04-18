using ApplicationCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.WebSite.ViewsModels.Ingrediente;

namespace UI.WebSite.Controllers
{
    public class IngredientesController : Controller
    {
        private readonly IIngredienteService _service;

        public IngredientesController(IIngredienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll().ToViewsModels());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IngredienteVM ingrediente)
        {
            if (ModelState.IsValid)
            {
                _service.Add(ingrediente.ToModel());

                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IngredienteVM ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(ingrediente.ToModel());
                }
                catch (Exception ex)
                {
                    if (!IngredienteExists(ingrediente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ingrediente = _service.Get(id);
            _service.Remove(ingrediente);
            return RedirectToAction("Index");
        }

        private bool IngredienteExists(int id)
        {
            return _service.Get(id) == null ? false : true;
        }
    }
}