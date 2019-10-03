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
    [Authorize(Policy = "EmployeeTimePoint")]
    public class TimePointsController : Controller
    {
        private readonly TimePointService _timePointService;
        private readonly EmployeeService _employeeService;

        public TimePointsController(TimePointService timePointService, EmployeeService employeeService)
        {
            _timePointService = timePointService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var employee = await _employeeService.FindAllAsync();
            var viewModel = new TimePoint { Employees = employee };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimePoint timePoint)
        {
            if (!ModelState.IsValid)
            {
                var employee = await _employeeService.FindAllAsync();
                var viewModel = new TimePoint { Employees = employee };
                return View(viewModel);
            }
            await _timePointService.InsertAsync(timePoint);
            return RedirectToAction(nameof(Create));
        }
    }
}