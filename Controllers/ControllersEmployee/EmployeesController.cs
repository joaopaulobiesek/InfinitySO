using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsEmployee;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersEmployee
{
    [Authorize(Policy = "EmployeeEmployee")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly MainBoardService _mainBoardService;
        private readonly SectorService _sectorService;
        private readonly ScaleService _scaleService;

        public EmployeesController(EmployeeService employeeService, MainBoardService mainBoardService, SectorService sectorService, ScaleService scaleService)
        {
            _employeeService = employeeService;
            _mainBoardService = mainBoardService;
            _sectorService = sectorService;
            _scaleService = scaleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var mainBoard = await _mainBoardService.FindAllAsync();
            var sector = await _sectorService.FindAllAsync();
            var scale = await _scaleService.FindAllAsync();
            var viewModel = new Employee { MainBoards = mainBoard, Sectors = sector, Scales = scale, Admission = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Resignation = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var mainBoard = await _mainBoardService.FindAllAsync();
                var sector = await _sectorService.FindAllAsync();
                var scale = await _scaleService.FindAllAsync();
                var viewModel = new Employee { MainBoards = mainBoard, Sectors = sector, Scales = scale, Admission = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Resignation = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) };
                return View(viewModel);
            }
            await _employeeService.InsertAsync(employee);
            return RedirectToAction(nameof(Create));
        }
    }
}