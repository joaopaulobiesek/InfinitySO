using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    public class SupplyAddsController : Controller
    {
        private readonly SupplyAddService _supplyAddService;

        public SupplyAddsController(SupplyAddService supplyAddService)
        {
            _supplyAddService = supplyAddService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _supplyAddService.FindAllIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            var viewModel = new SupplyAdd { SupplyAdds = obj };
            return View(viewModel);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}