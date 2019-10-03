using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsEmployee;
using InfinitySO.Services.ServicesEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersEmployee
{
    [Authorize(Policy = "EmployeeScale")]
    public class ScalesController : Controller
    {
        private readonly ScaleService _scaleService;
        private readonly JourneyService _journeyService;

        public ScalesController(ScaleService scaleService, JourneyService journeyService)
        {
            _scaleService = scaleService;
            _journeyService = journeyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var journey = await _journeyService.FindAllAsync();
            var viewModel = new Scale { Journeys = journey };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Scale scale)
        {
            if (!ModelState.IsValid)
            {
                var journey = await _journeyService.FindAllAsync();
                var viewModel = new Scale { Journeys = journey };
                return View(viewModel);
            }
            await _scaleService.InsertAsync(scale);
            return RedirectToAction(nameof(Create));
        }
    }
}