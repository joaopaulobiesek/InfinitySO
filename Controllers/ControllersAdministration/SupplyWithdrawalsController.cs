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
    public class SupplyWithdrawalsController : Controller
    {
        private readonly SupplyWithdrawalService _supplyWithdrawalService;

        public SupplyWithdrawalsController(SupplyWithdrawalService supplyWithdrawalService)
        {
            _supplyWithdrawalService = supplyWithdrawalService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _supplyWithdrawalService.FindAllIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            var viewModel = new SupplyWithdrawal { SupplyWithdrawals = obj };
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