using System;
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
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersCertificate
{
    public class CertificatesController : Controller
    {
        private readonly CertificateCourseService _certificateCourseService;
        private readonly CertificateService _certificateService;
        private readonly MainBoardService _mainBoardService;

        public CertificatesController(CertificateCourseService certificateCourseService, CertificateService certificateService, MainBoardService mainBoardService)
        {
            _certificateCourseService = certificateCourseService;
            _certificateService = certificateService;
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
            ViewData["CodCertificateCourse"] = id.Value;
            var certificates = await _certificateService.FindAllIdAsync(id.Value);
            var viewModel = new Certificate { Certificates = certificates, CertificateCourse = obj };
            return View(viewModel);
        }

        public async Task<IActionResult> Register(int? id)
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
            ViewData["CodCertificateCourse"] = id.Value;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Certificate certificate, string searchCPF)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string[] cpfs = searchCPF.Split("- CPF: ");
            string cpf = cpfs[1].Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            var mainBoards = await _mainBoardService.FindByCPFAsync(cpf);

            ViewData["Error"] = "Erro ao tentar carregar informações, tente novamente mais tarde!" + certificate.Id + " - " + certificate.MainBoardId + " - " + certificate.CertificateCourseId + " - " + certificate.Pay + " - " + certificate.Approved;
            return View();
            /*
            if (mainBoards != null)
            {
                await _certificateService.InsertAsync(certificate, mainBoards);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Error"] = "Erro ao tentar carregar informações, tente novamente mais tarde!";
                return View();
            }*/
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