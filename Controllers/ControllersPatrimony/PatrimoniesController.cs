using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesPatrimony;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersPatrimony
{
    public class PatrimoniesController : Controller
    {
        private readonly PatrimonyService _patrimonyService;
        private readonly PlaceService _placeService;
        private readonly ProductService _productService;

        public PatrimoniesController(PatrimonyService patrimonyService, PlaceService placeService, ProductService productService)
        {
            _patrimonyService = patrimonyService;
            _placeService = placeService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var patrimonies = await _patrimonyService.FindAllAsync();
            var places = await _placeService.FindAllAsync();
            var products = await _productService.FindAllAsync();
            var viewModel = new Patrimony { Places = places, Products = products, Patrimonies = patrimonies };
            return View(viewModel);
        }

        public async Task<IActionResult> Register()
        {
            var places = await _placeService.FindAllAsync();
            var products = await _productService.FindAllAsync();
            var viewModel = new Patrimony { Places = places, Products = products, DateBuy = DateTime.Now, NextMaintenanceDate = DateTime.Now };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Patrimony patrimony)
        {
            var places = await _placeService.FindAllAsync();
            var products = await _productService.FindAllAsync();
            var viewModel = new Patrimony { Places = places, Products = products, DateBuy = DateTime.Now, NextMaintenanceDate = DateTime.Now };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var obj = await _patrimonyService.FindByKeyAsync(patrimony.KeyPatrimony);
            if (obj == null)
            {
                await _patrimonyService.InsertAsync(patrimony);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Result"] = "Chave do patrimônio já cadastrado!";
                return View(viewModel);
            }
        }
    }
}