using System;
using System.Diagnostics;
using System.Threading.Tasks;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesCertificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersCertificate
{
    [Authorize(Policy = "CertificateCertificateCourse")]
    public class CertificateCoursesController : Controller
    {
        private readonly CertificateCourseService _certificateCourseService;
        private readonly CertificateProgrammaticService _certificateProgrammaticService;
        private readonly CompanyService _companyService;

        public CertificateCoursesController(CertificateCourseService certificateCourseService, CertificateProgrammaticService certificateProgrammaticService, CompanyService companyService)
        {
            _certificateCourseService = certificateCourseService;
            _certificateProgrammaticService = certificateProgrammaticService;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var certificateCourses = await _certificateCourseService.FindAllAsync();
            var viewModel = new CertificateFormViewModel { CertificateCourses = certificateCourses };
            return View(viewModel);
        }

        [Authorize(Policy = "CertificateCertificateCourseCreate")]
        [Authorize(Policy = "CertificateCertificateProgrammaticCreate")]
        public async Task<IActionResult> Register()
        {
            var companies = await _companyService.FindAllAsync();
            var viewModel = new CertificateFormViewModel { Companies = companies };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CertificateCertificateCourseCreate")]
        [Authorize(Policy = "CertificateCertificateProgrammaticCreate")]
        public async Task<IActionResult> Register(CertificateFormViewModel certificateFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyService.FindAllAsync();
                var viewModel = new CertificateFormViewModel { Companies = companies/*, InitialDate = DateTime.Now, FinalDate = DateTime.Now*/ };
                return View(viewModel);
            }
            await _certificateCourseService.InsertAsync(certificateFormViewModel);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "CertificateCertificateCourseEdit")]
        [Authorize(Policy = "CertificateCertificateProgrammaticEdit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _certificateCourseService.FindByIdAsync(id.Value);
            var obj2 = await _certificateProgrammaticService.FindAllIdAsync(obj.Id);
            if (obj == null || obj2 == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new CertificateFormViewModel { CertificateCourse = obj, CertificateProgrammatics = obj2 };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CertificateCertificateCourseEdit")]
        [Authorize(Policy = "CertificateCertificateProgrammaticEdit")]
        public async Task<IActionResult> Edit(int? id, CertificateFormViewModel certificateFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var obj = await _certificateCourseService.FindByIdAsync(id.Value);
                var obj2 = await _certificateProgrammaticService.FindAllIdAsync(obj.Id);
                var viewModel = new CertificateFormViewModel { CertificateCourse = obj, CertificateProgrammatics = obj2 };
                return View(viewModel);
            }
            if (id != certificateFormViewModel.CertificateCourse.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _certificateCourseService.UpdateAsync(certificateFormViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
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