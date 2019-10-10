using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Services.ServicesPatrimony;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersPatrimony
{
    public class HistoricalPatrimonyController : Controller
    {
        private readonly HistoricPatrimonyService _historicPatrimonyService;
        private readonly PatrimonyService _patrimonyService;

        public HistoricalPatrimonyController(HistoricPatrimonyService historicPatrimonyService, PatrimonyService patrimonyService)
        {
            _historicPatrimonyService = historicPatrimonyService;
            _patrimonyService = patrimonyService;
        }

        public async Task<IActionResult> Index()
        {
            var historicalPatrimony = await _historicPatrimonyService.FindAllAsync();
            var patrimonies = await _patrimonyService.FindAllAsync();
            var viewModel = new HistoricPatrimony { HistoricalPatrimony = historicalPatrimony, Patrimonies = patrimonies };
            return View(viewModel);
        }

        public async Task<IActionResult> Register()
        {
            var historicalPatrimony = await _historicPatrimonyService.FindAllAsync();
            var patrimonies = await _patrimonyService.FindAllAsync();
            var viewModel = new HistoricPatrimony { HistoricalPatrimony = historicalPatrimony, Patrimonies = patrimonies, DateDescription = DateTime.Now };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(HistoricPatrimony historicPatrimony)
        {
            if (!ModelState.IsValid)
            {
                var historicalPatrimony = await _historicPatrimonyService.FindAllAsync();
                var patrimonies = await _patrimonyService.FindAllAsync();
                var viewModel = new HistoricPatrimony { HistoricalPatrimony = historicalPatrimony, Patrimonies = patrimonies, DateDescription = DateTime.Now };
                return View(viewModel);
            }
            await _historicPatrimonyService.InsertAsync(historicPatrimony);
            return RedirectToAction(nameof(Index));
        }
    }
}