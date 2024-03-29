﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ModelsCertificate;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesCertificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersCertificate
{
    [Authorize(Policy = "CertificateCertificate")]
    public class CertificatesController : Controller
    {
        private readonly CertificateCourseService _certificateCourseService;
        private readonly CertificateService _certificateService;
        private readonly CertificateProgrammaticService _certificateProgrammaticService;
        private readonly MainBoardService _mainBoardService;

        public CertificatesController(CertificateCourseService certificateCourseService, CertificateService certificateService, CertificateProgrammaticService certificateProgrammaticService, MainBoardService mainBoardService)
        {
            _certificateCourseService = certificateCourseService;
            _certificateService = certificateService;
            _certificateProgrammaticService = certificateProgrammaticService;
            _mainBoardService = mainBoardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetName(string term)
        {
            if (term.Length > 3)
            {
                List<JsonAutoCompeteMainBoard> list = new List<JsonAutoCompeteMainBoard>();
                var ListNames = await _mainBoardService.FindAllAsync();
                foreach (var item in ListNames)
                {
                    var name = RemoveAccents(item.Name) + " " + RemoveAccents(item.LastName) + " - CPF: " + item.CPF.Trim().Replace(".", "").Replace("-", "");
                    list.Add(new JsonAutoCompeteMainBoard() { Name = name });
                }
                var result = (from N in list where N.Name.Contains(RemoveAccents(term.ToUpper())) select new { Value = N.Name });
                return Json(result);
            }
            else
            {
                return Json("");
            }
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _certificateCourseService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            var certificates = await _certificateService.FindAllIdAsync(id.Value);
            var viewModel = new CertificateFormViewModel { Certificates = certificates, CertificateCourse = obj };
            return View(viewModel);
        }

        [Authorize(Policy = "CertificateCertificateCreate")]
        public async Task<IActionResult> Register()
        {
            var certificateCourses = await _certificateCourseService.FindAllAsync();
            var viewModel = new CertificateFormViewModel { CertificateCourses = certificateCourses };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CertificateCertificateCreate")]
        public async Task<IActionResult> Register(CertificateFormViewModel certificateFormViewModel, string searchCPF)
        {
            var certificateCourses = await _certificateCourseService.FindAllAsync();
            var certificateCoursesId = await _certificateCourseService.FindByIdAsync(certificateFormViewModel.Certificate.CertificateCourseId);
            var certificates = await _certificateService.FindAllIdAsync(certificateFormViewModel.Certificate.CertificateCourseId);
            var viewModel = new CertificateFormViewModel { CertificateCourses = certificateCourses };
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }           
            try
            {
                string[] cpfs = searchCPF.Split("- CPF: ");
                string cpf = cpfs[1].Trim().Replace(".", "").Replace("-", "");
                cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                var mainBoards = await _mainBoardService.FindByCPFAsync(cpf);
                if (mainBoards != null)
                {
                    if (certificates.Count < certificateCoursesId.Amount)
                    {
                        await _certificateService.InsertAsync(certificateFormViewModel, mainBoards);
                        return RedirectToAction("Index", new { id = certificateFormViewModel.Certificate.CertificateCourseId });
                    }
                    else
                    {
                        ViewData["Error"] = "Limite da inscritos atingido!";
                        return View(viewModel);
                    }
                }
                else
                {
                    ViewData["Error"] = "Erro ao tentar carregar informações, tente novamente mais tarde!";
                    return View(viewModel);
                }
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Send(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var certificates = await _certificateService.FindByIdAsync(id.Value);
            var certificateCourses = await _certificateCourseService.FindByIdAsync(certificates.CertificateCourseId);
            var certificateProgrammatics = await _certificateProgrammaticService.FindAllIdAsync(certificates.CertificateCourseId);
            var viewModel = new CertificateFormViewModel { CertificateCourse = certificateCourses, Certificate = certificates, CertificateProgrammatics = certificateProgrammatics };
            return View(viewModel);
        }

        [Authorize(Policy = "CertificateCertificateEdit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _certificateService.FindByIdAsync(id.Value);
            var obj2 = await _certificateCourseService.FindByIdAsync(obj.CertificateCourseId);
            if (obj == null || obj2 == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new CertificateFormViewModel { Certificate = obj, CertificateCourse = obj2 };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CertificateCertificateEdit")]
        public async Task<IActionResult> Edit(int? id, CertificateFormViewModel certificateFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var obj = await _certificateService.FindByIdAsync(id.Value);
                var obj2 = await _certificateCourseService.FindByIdAsync(obj.CertificateCourseId);
                var viewModel = new CertificateFormViewModel { Certificate = obj, CertificateCourse = obj2 };
                return View(viewModel);
            }
            if (id != certificateFormViewModel.Certificate.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _certificateService.UpdateAsync(certificateFormViewModel);
                return RedirectToAction("Index", new { id = certificateFormViewModel.Certificate.CertificateCourseId });

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

        private string RemoveAccents(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }
    }
}