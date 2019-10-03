using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministrationCategory")]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly PlaceService _placeService;

        public CategoriesController(CategoryService categoryService, PlaceService placeService)
        {
            _categoryService = categoryService;
            _placeService = placeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var places = await _placeService.FindAllAsync();
            var viewModel = new Category { Places = places };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                var places = await _placeService.FindAllAsync();
                var viewModel = new Category { Places = places };
                return View(viewModel);
            }
            await _categoryService.InsertAsync(category);
            return RedirectToAction(nameof(Create));
        }
    }
}