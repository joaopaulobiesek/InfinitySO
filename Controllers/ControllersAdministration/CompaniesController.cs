using System;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{ //05.829.785/0001-23
    [Authorize(Policy = "AdministrationCompany")]
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var company = await _companyService.FindAllAsync();
            var viewModel = new CompanyFormViewModel { Companys = company };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string cnpj = company.CNPJ;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            cnpj = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            var obj = await _companyService.FindByCNPJAsync(cnpj);
            if (obj == null)
            {
                await _companyService.InsertCreateAsync(company);
                return RedirectToAction(nameof(Create));
            }
            else
            {
                ViewData["ResultCadastroErro"] = "CNPJ já cadastrado!";
                return View("Create", company);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CompanyFormViewModel companyFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string cnpj = companyFormViewModel.Company.CNPJ;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            cnpj = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            var obj = await _companyService.FindByCNPJAsync(cnpj);
            if (obj == null)
            {
                await _companyService.InsertAsync(companyFormViewModel);
                return RedirectToAction(nameof(Register));
            }
            else
            {
                ViewData["Result"] = "CNPJ já cadastrado!";
                return View("Register", companyFormViewModel);
            }
        }
    }
}