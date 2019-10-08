using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesPatrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersPatrimony
{
    [Authorize(Policy = "PatrimonyPatrimonyKey")]
    public class PatrimonyKeysController : Controller
    {
        private readonly PatrimonyKeyService _patrimonyKeyService;
        private readonly PatrimonyService _patrimonyService;
        private readonly SectorService _sectorService;

        public PatrimonyKeysController(PatrimonyKeyService patrimonyKeyService, PatrimonyService patrimonyService, SectorService sectorService)
        {
            _patrimonyKeyService = patrimonyKeyService;
            _patrimonyService = patrimonyService;
            _sectorService = sectorService;
        }

        public async Task<IActionResult> Index()
        {
            var patrimonyKeys = await _patrimonyKeyService.FindAllAsync();
            var viewModel = new PatrimonyKey { PatrimonyKeys = patrimonyKeys };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var patrimony = await _patrimonyService.FindAllAsync();
            var sector = await _sectorService.FindAllAsync();
            var viewModel = new PatrimonyKey { Patrimonies = patrimony, Sectors = sector };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatrimonyKey patrimonyKey)
        {
            if (!ModelState.IsValid)
            {
                var patrimony = await _patrimonyService.FindAllAsync();
                var sector = await _sectorService.FindAllAsync();
                var viewModel = new PatrimonyKey { Patrimonies = patrimony, Sectors = sector };
                return View(viewModel);
            }
            await _patrimonyKeyService.InsertAsync(patrimonyKey);
            return RedirectToAction(nameof(Create));
        }
    }
}