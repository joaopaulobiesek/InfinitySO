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
    [Authorize(Policy = "StudentSemester")]
    public class SemestersController : Controller
    {
        private readonly SemesterService _semesterService;

        public SemestersController(SemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Semester semester)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _semesterService.InsertAsync(semester);
            return RedirectToAction(nameof(Create));
        }
    }
}