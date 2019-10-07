using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministrationPlace")]
    public class PlacesController : Controller
    {
        private readonly PlaceService _placeService;
        private readonly CompanyService _companyService;

        public PlacesController(PlaceService placeService, CompanyService companyService)
        {
            _placeService = placeService;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var places = await _placeService.FindAllAsync();
            var companies = await _companyService.FindAllAsync();
            var viewModel = new Place { Places = places, Companies = companies };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var companies = await _companyService.FindAllAsync();
            var viewModel = new Place { Companies = companies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Place place)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.FindAllAsync();
                var viewModel = new Place { Companies = companies };
                return View(viewModel);
            }
            await _placeService.InsertAsync(place);
            return RedirectToAction(nameof(Create));
        }
    }
}