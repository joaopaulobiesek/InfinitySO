using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Services.ServicesPatrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersPatrimony
{
    [Authorize(Policy = "PatrimonyPatrimonyKeyDescription")]
    public class PatrimonyKeyDescriptionsController : Controller
    {
        private readonly PatrimonyKeyDescriptionService _patrimonyKeyDescriptionService;
        private readonly PatrimonyKeyService _patrimonyKeyService;

        public PatrimonyKeyDescriptionsController(PatrimonyKeyDescriptionService patrimonyKeyDescriptionService, PatrimonyKeyService patrimonyKeyService)
        {
            _patrimonyKeyDescriptionService = patrimonyKeyDescriptionService;
            _patrimonyKeyService = patrimonyKeyService;
        }

        public async Task<IActionResult> Index()
        {
            var patrimonyKeyDescriptions = await _patrimonyKeyDescriptionService.FindAllAsync();
            var viewModel = new PatrimonyKeyDescription { PatrimonyKeyDescriptions = patrimonyKeyDescriptions, DateDescription = DateTime.Now };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var patrimonyKey = await _patrimonyKeyService.FindAllAsync();
            var viewModel = new PatrimonyKeyDescription { PatrimonyKeys = patrimonyKey, DateDescription = DateTime.Now };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatrimonyKeyDescription patrimonyKeyDescription)
        {
            if (!ModelState.IsValid)
            {
                var patrimonyKey = await _patrimonyKeyService.FindAllAsync();
                var patrimonyKeyDescriptions = await _patrimonyKeyDescriptionService.FindAllAsync();
                var viewModel = new PatrimonyKeyDescription { PatrimonyKeys = patrimonyKey, PatrimonyKeyDescriptions = patrimonyKeyDescriptions, DateDescription = DateTime.Now };
                return View(viewModel);
            }
            await _patrimonyKeyDescriptionService.InsertAsync(patrimonyKeyDescription);
            return RedirectToAction(nameof(Create));
        }
    }
}