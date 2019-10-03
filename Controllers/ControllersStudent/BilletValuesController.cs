using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Services.ServicesStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersStudent
{
    [Authorize(Policy = "StudentBilletValue")]
    public class BilletValuesController : Controller
    {
        private readonly BilletValueService _billetValueService;

        public BilletValuesController(BilletValueService billetValueService)
        {
            _billetValueService = billetValueService;
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
        public async Task<IActionResult> Create(BilletValue billetValue)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _billetValueService.InsertAsync(billetValue);
            return RedirectToAction(nameof(Create));
        }
    }
}