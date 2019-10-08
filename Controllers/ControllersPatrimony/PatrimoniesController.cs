using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesPatrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersPatrimony
{
    [Authorize(Policy = "PatrimonyPatrimony")]
    public class PatrimoniesController : Controller
    {
        private readonly PatrimonyService _patrimonyService;
        private readonly CategoryService _categoryService;
        private readonly SubCategoryService _subCategoryService;

        public PatrimoniesController(PatrimonyService patrimonyService, CategoryService categoryService, SubCategoryService subCategoryService)
        {
            _patrimonyService = patrimonyService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var patrimonies = await _patrimonyService.FindAllAsync();
            var viewModel = new Patrimony { Patrimonies = patrimonies };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var category = await _categoryService.FindAllAsync();
            var subCategory = await _subCategoryService.FindAllAsync();
            var viewModel = new Patrimony { Categories = category, SubCategories = subCategory};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patrimony patrimony)
        {
            var category = await _categoryService.FindAllAsync();
            var subCategory = await _subCategoryService.FindAllAsync();
            var viewModel = new Patrimony { Categories = category, SubCategories = subCategory };
            if (!ModelState.IsValid)
            {               
                return View(viewModel);
            }
            var obj = await _patrimonyService.FindByCatSubAsync(patrimony.CategoryId, patrimony.SubCategoryId);
            if (obj == null)
            {
                await _patrimonyService.InsertAsync(patrimony);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Error"] = "Patrimônio já cadastrado neste local. Favor Editar o já existente!";
                return View(viewModel);
            }
        }
    }
}