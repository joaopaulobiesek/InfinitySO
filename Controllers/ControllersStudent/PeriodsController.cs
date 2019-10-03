using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Services.ServicesStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersStudent
{
    [Authorize(Policy = "StudentPeriod")]
    public class PeriodsController : Controller
    {
        private readonly PeriodService _periodService;
        private readonly CourseService _courseService;
        private readonly SemesterService _semesterService;

        public PeriodsController(PeriodService periodService, CourseService courseService, SemesterService semesterService)
        {
            _periodService = periodService;
            _courseService = courseService;
            _semesterService = semesterService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var course = await _courseService.FindAllAsync();
            var semester = await _semesterService.FindAllAsync();
            var viewModel = new Period { Semesters = semester, Courses = course };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Period period)
        {
            if (!ModelState.IsValid)
            {
                var course = await _courseService.FindAllAsync();
                var semester = await _semesterService.FindAllAsync();
                var viewModel = new Period { Semesters = semester, Courses = course };
                return View(viewModel);
            }
            await _periodService.InsertAsync(period);
            return RedirectToAction(nameof(Create));
        }
    }
}