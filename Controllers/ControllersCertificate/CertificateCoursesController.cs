using System;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsCertificate;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesCertificate;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersCertificate
{
    public class CertificateCoursesController : Controller
    {
        private readonly CertificateCourseService _certificateCourseService;
        private readonly CompanyService _companyService;

        public CertificateCoursesController(CertificateCourseService certificateCourseService, CompanyService companyService)
        {
            _certificateCourseService = certificateCourseService;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var certificateCourses = await _certificateCourseService.FindAllAsync();
            var viewModel = new CertificateCourse { CertificateCourses = certificateCourses, InitialDate = DateTime.Now, FinalDate = DateTime.Now };
            return View(viewModel);
        }

        public async Task<IActionResult> Register()
        {
            var companies = await _companyService.FindAllAsync();
            var viewModel = new CertificateCourse { Companies = companies, InitialDate = DateTime.Now, FinalDate = DateTime.Now };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CertificateCourse certificateCourse)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.FindAllAsync();
                var viewModel = new CertificateCourse { Companies = companies, InitialDate = DateTime.Now, FinalDate = DateTime.Now };
                return View(viewModel);
            }
            await _certificateCourseService.InsertAsync(certificateCourse);
            return RedirectToAction(nameof(Index));
        }
    }
}