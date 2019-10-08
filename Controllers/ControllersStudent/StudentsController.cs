using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersStudent
{
    [Authorize(Policy = "StudentStudent")]
    public class StudentsController : Controller
    {
        private readonly StudentService _studentService;
        private readonly MainBoardService _mainBoardService;
        private readonly PeriodService _periodService;

        public StudentsController(StudentService studentService, MainBoardService mainBoardService, PeriodService periodService)
        {
            _studentService = studentService;
            _mainBoardService = mainBoardService;
            _periodService = periodService;
        }

        public async Task<IActionResult> Index()
        {
            var period = await _periodService.FindAllAsync();
            var student = await _studentService.FindAllAsync();
            var viewModel = new StudentFormViewModel { Periods = period, Students = student };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {
            var mainBoard = await _mainBoardService.FindAllAsync();
            var period = await _periodService.FindAllAsync();
            var viewModel = new Student { MainBoards = mainBoard, Periods = period };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                var mainBoard = await _mainBoardService.FindAllAsync();
                var period = await _periodService.FindAllAsync();
                var viewModel = new Student { MainBoards = mainBoard, Periods = period };
                return View(viewModel);
            }
            await _studentService.InsertAsync(student);
            return RedirectToAction(nameof(Create));
        }

        public async Task<IActionResult> CompleteRegistration()
        {
            var period = await _periodService.FindAllAsync();
            var viewModel = new StudentFormViewModel { Periods = period };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteRegistration(StudentFormViewModel studentFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var period = await _periodService.FindAllAsync();
                var viewModel = new StudentFormViewModel { Periods = period };
                return View(viewModel);
            }

            string cpf = studentFormViewModel.MainBoard.CPF.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            var obj = await _mainBoardService.FindByCPFAsync(cpf);
            var obj2 = await _studentService.FindByEADAsync(studentFormViewModel.Student.EAD);
            var obj3 = await _mainBoardService.FindByEmailAsync(studentFormViewModel.MainBoard.Email);
            if (obj != null)
            {
                ViewData["Result"] = "CPF já cadastrado!";
                return View();
            }
            if (obj2 != null)
            {
                ViewData["Result"] = "EAD já cadastrado!";
                return View();
            }
            if (obj3 != null)
            {
                ViewData["Result"] = "E-mail já cadastrado!";
                return View();
            }
            await _studentService.InsertCompleteAsync(studentFormViewModel);
            return RedirectToAction(nameof(CompleteRegistration));
        }

        public async Task<IActionResult> RegistrationEAD()
        {
            var period = await _periodService.FindAllAsync();
            var mainBoards = await _mainBoardService.FindAllAsync();
            var viewModel = new StudentFormViewModel { Periods = period, MainBoards = mainBoards };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationEAD(StudentFormViewModel studentFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var period = await _periodService.FindAllAsync();
                var mainBoards = await _mainBoardService.FindAllAsync();
                var viewModel = new StudentFormViewModel { Periods = period, MainBoards = mainBoards };
                return View(viewModel);
            }

            var obj = await _studentService.FindByEADAsync(studentFormViewModel.Student.EAD);
            if (obj != null)
            {
                ViewData["Result"] = "EAD já cadastrado!";
                return View();
            }
            await _studentService.InsertEADAsync(studentFormViewModel);
            return RedirectToAction(nameof(RegistrationEAD));
        }
    }
}