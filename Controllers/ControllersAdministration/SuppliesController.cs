using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    public class SuppliesController : Controller
    {
        private readonly SupplyService _supplyService;

        public SuppliesController(SupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        public async Task<IActionResult> Index()
        {
            var supplies = await _supplyService.FindAllAsync();
            var viewModel = new Supply { Supplies = supplies };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supply supply)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var obj = await _supplyService.FindByNameAsync(supply.Name);
            if (obj == null)
            {
                await _supplyService.InsertAsync(supply);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Result"] = supply.Name + " já cadastrado!";
                return View("Create", supply);
            }
        }
    }
}