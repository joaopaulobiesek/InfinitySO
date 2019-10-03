using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministrationAddress")]
    public class AddressesController : Controller
    {
        private readonly AddressService _addressService;
        private readonly MainBoardService _mainBoardService;
        private readonly CompanyService _companyService;

        public AddressesController(AddressService addressService, MainBoardService mainBoardService, CompanyService companyService)
        {
            _addressService = addressService;
            _mainBoardService = mainBoardService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var mainBoard = await _mainBoardService.FindAllAsync();
            var companies = await _companyService.FindAllAsync();
            var viewModel = new Address { MainBoards = mainBoard, Companies = companies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            if (!ModelState.IsValid)
            {
                var mainBoard = await _mainBoardService.FindAllAsync();
                var companies = await _companyService.FindAllAsync();
                var viewModel = new Address { MainBoards = mainBoard, Companies = companies };
                return View(viewModel);
            }
            await _addressService.InsertAsync(address);
            return RedirectToAction(nameof(Create));
        }
    }
}