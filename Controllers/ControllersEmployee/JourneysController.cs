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
    [Authorize(Policy = "EmployeeJourney")]
    public class JourneysController : Controller
    {
        private readonly JourneyService _journeyService;

        public JourneysController(JourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Journey journey)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _journeyService.InsertAsync(journey);
            return RedirectToAction(nameof(Create));
        }
    }
}