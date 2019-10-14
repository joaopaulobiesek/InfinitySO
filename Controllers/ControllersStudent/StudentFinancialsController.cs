using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersStudent
{
    [Authorize(Policy = "StudentStudentFinancial")]
    public class StudentFinancialsController : Controller
    {
        private readonly StudentFinancialService _studentFinancialService;
        private readonly StudentService _studentService;
        private readonly BilletValueService _billetValueService;
        private readonly MainBoardService _mainBoardService;

        public StudentFinancialsController(StudentFinancialService studentFinancialService, StudentService studentService, BilletValueService billetValueService, MainBoardService mainBoardService)
        {
            _studentFinancialService = studentFinancialService;
            _studentService = studentService;
            _billetValueService = billetValueService;
            _mainBoardService = mainBoardService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _studentFinancialService.FindAllAsync();
            var viewModel = new StudentFinancialFormViewModel { StudentFinancials = list };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetName(string term)
        {
            if (term.Length > 5)
            {
                List<JsonAutoCompeteStudent> list = new List<JsonAutoCompeteStudent>();
                var ListNames = await _studentService.FindAllAsync();
                foreach (var item in ListNames)
                {
                    var name = item.MainBoard.Name + " " + item.MainBoard.LastName + " - CPF: " + item.MainBoard.CPF.Trim().Replace(".", "").Replace("-", "") + " - EAD: " + item.EAD;
                    list.Add(new JsonAutoCompeteStudent() { Name = name });
                }
                var result = (from N in list where N.Name.Contains(term.ToUpper()) select new { Value = N.Name });
                return Json(result);
            }
            else
            {
                return Json("");
            }
        }

        [Authorize(Policy = "StudentStudentFinancialCreate")]
        public async Task<IActionResult> Create()
        {
            var student = await _studentService.FindAllAsync();
            var viewModel = new StudentFinancialFormViewModel { Students = student };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "StudentStudentFinancialCreate")]
        public async Task<IActionResult> Create(StudentFinancial studentFinancial)
        {
            if (!ModelState.IsValid)
            {
                var student = await _studentService.FindAllAsync();
                var viewModel = new StudentFinancialFormViewModel { Students = student };
                return View(viewModel);
            }
            await _studentFinancialService.InsertCreateAsync(studentFinancial);
            return RedirectToAction(nameof(Create));
        }

        [Authorize(Policy = "StudentStudentFinancialCreate")]
        public async Task<IActionResult> Register()
        {
            var student = await _studentService.FindAllAsync();
            var mainBoards = await _mainBoardService.FindAllAsync();
            var viewModel = new StudentFinancialFormViewModel { MainBoards = mainBoards, Students = student };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "StudentStudentFinancialCreate")]
        public async Task<IActionResult> Register(StudentFinancialFormViewModel studentFinancialFormViewModel, string searchEAD)
        {
            var student = await _studentService.FindAllAsync();
            var mainBoards = await _mainBoardService.FindAllAsync();
            var viewModel = new StudentFinancialFormViewModel { MainBoards = mainBoards, Students = student };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            string[] eads = searchEAD.Split("- EAD: ");
            var ead = await _studentService.FindByEADAsync(eads[1]);
            if (ead != null)
            {
                await _studentFinancialService.InsertAsync(studentFinancialFormViewModel, ead);
               return RedirectToAction(nameof(Register));

            }
            else
            {
                ViewData["Error"] = "Erro ao tentar carregar informações, tente novamente mais tarde!";
                return View(viewModel);
            }
        }

        [Authorize(Policy = "StudentStudentFinancialEdit")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _billetValueService.FindByIdAsync(id.Value);
            List<BilletValue> billetValues = await _billetValueService.FindByIdListAsync(id.Value);
            if (obj == null || !billetValues.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new StudentFinancialFormViewModel { MainBoard = obj.StudentFinancial.Student.MainBoard, Student = obj.StudentFinancial.Student, StudentFinancial = obj.StudentFinancial, BilletValues = billetValues };
            return View(viewModel);
        }

        [Authorize(Policy = "StudentStudentFinancialEdit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _billetValueService.FindByIdAsync(id.Value);
            List<BilletValue> billetValues = await _billetValueService.FindByIdListAsync(id.Value);
            if (obj == null || !billetValues.Any())
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new StudentFinancialFormViewModel { MainBoard = obj.StudentFinancial.Student.MainBoard, Student = obj.StudentFinancial.Student, StudentFinancial = obj.StudentFinancial, BilletValues = billetValues };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "StudentStudentFinancialEdit")]
        public async Task<IActionResult> Edit(int id, StudentFinancialFormViewModel studentFinancialFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var obj = await _billetValueService.FindByIdAsync(id);
                List<BilletValue> billetValues = await _billetValueService.FindByIdListAsync(id);
                var viewModel = new StudentFinancialFormViewModel { MainBoard = obj.StudentFinancial.Student.MainBoard, Student = obj.StudentFinancial.Student, StudentFinancial = obj.StudentFinancial, BilletValues = billetValues };
                return View(viewModel);
            }
            if (id != studentFinancialFormViewModel.StudentFinancial.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _studentFinancialService.UpdateAsync(studentFinancialFormViewModel);
                return RedirectToAction(nameof(Index));

            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                // minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                minDate = DateTime.Now;
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now.AddDays(+1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _billetValueService.FindByDateAsync(minDate, maxDate);
            StudentFinancialFormViewModel viewModel = new StudentFinancialFormViewModel { BilletValues = result };
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