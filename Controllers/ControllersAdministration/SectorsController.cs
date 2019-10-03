using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministrationSector")]
    public class SectorsController : Controller
    {
        private readonly SectorService _sectorService;
        private readonly DepartmentService _departmentService;

        public SectorsController(SectorService sectorService, DepartmentService DepartmentService)
        {
            _sectorService = sectorService;
            _departmentService = DepartmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new Sector { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sector sector)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new Sector { Departments = departments };
                return View(viewModel);
            }
            await _sectorService.InsertAsync(sector);
            return RedirectToAction(nameof(Create));
        }
    }
}