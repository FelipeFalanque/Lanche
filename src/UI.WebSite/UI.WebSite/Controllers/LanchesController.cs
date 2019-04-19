using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using UI.WebSite.ViewsModels.Lanche;

namespace UI.WebSite.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheService _serviceLanche;
        private readonly IIngredienteService _serviceIngrediente;

        public LanchesController(ILancheService serviceLanche,
            IIngredienteService serviceIngrediente)
        {
            _serviceLanche = serviceLanche;
            _serviceIngrediente = serviceIngrediente;
        }

        public IActionResult Index()
        {
            return View(_serviceLanche.GetAll().ToViewsModels());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = _serviceLanche.Get(id);

            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche.ToViewModel());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = _serviceLanche.Get(id);
            var ingredientes = _serviceIngrediente.GetAll();
            ViewBag.Ingredientes = ingredientes;

            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LancheVM lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _serviceLanche.Update(lanche.ToModel());
                }
                catch (Exception ex)
                {
                    if (!LancheExists(lanche.Id))
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

            return View(lanche);
        }

        private bool LancheExists(int id)
        {
            return _serviceLanche.Get(id) == null ? false : true;
        }
    }
}