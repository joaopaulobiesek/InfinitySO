using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesStudent;
using InfinitySO.Services.ServicesSystem;
using Microsoft.AspNetCore.Authorization;
using InfinitySO.Models.Enums;
using InfinitySO.Models.ModelsSystem;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministratorSystemFullAcess")]
    public class ImportDataController : Controller
    {
        private readonly ImportDataService _importDataService;
        [Obsolete]
        private readonly IHostingEnvironment _appEnvironment;
        private readonly PeriodService _periodService;
        private readonly DownloadFileService _downloadFileService;
        private readonly DownloadFileDescriptionService _downloadFileDescriptionService;

        [Obsolete]
        public ImportDataController(ImportDataService importDataService, IHostingEnvironment appEnvironment, PeriodService periodService, DownloadFileService downloadFileService, DownloadFileDescriptionService downloadFileDescriptionService)
        {
            _importDataService = importDataService;
            _appEnvironment = appEnvironment;
            _periodService = periodService;
            _downloadFileService = downloadFileService;
            _downloadFileDescriptionService = downloadFileDescriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var downloadFile = await _downloadFileService.FindSystemAllAsync();
            var viewModel = new ImportDataFormViewModel { DownloadFiles = downloadFile };
            return View(viewModel);
        }

        public async Task<IActionResult> Import(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _downloadFileService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var viewModel = new DownloadFile { Id = obj.Id, NameFile = obj.NameFile, Path = obj.Path, TypeFile = obj.TypeFile };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(int id, DownloadFile downloadFile)
        {
            var obj = await _downloadFileService.FindByIdAsync(id);
            var viewModel = new DownloadFile { Id = obj.Id, NameFile = obj.NameFile, Path = obj.Path, TypeFile = obj.TypeFile };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (id != downloadFile.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                if (obj.CommandExecuted == CommandExecuted.NotExecuted)
                {
                    await _importDataService.InsertAsync(obj);
                    ViewData["Resultado"] = "Excel lido com sucesso!";
                    return View(viewModel);
                }
                else
                {
                    ViewData["Error"] = "Excel ja executado anteriormente!";
                    return View(viewModel);
                }
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> SendFile()
        {
            var period = await _periodService.FindAllAsync();
            var viewModel = new ImportDataFormViewModel { Periods = period };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> SendFile(List<IFormFile> files, ImportDataFormViewModel importDataFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var period = await _periodService.FindAllAsync();
                var viewModel = new ImportDataFormViewModel { Periods = period };
                return View(viewModel);
            }

            long sizeFiles = files.Sum(f => f.Length) / 1000;
            var pathFiles = Path.GetTempFileName();
            string pathFileEnd = "PathEnd";
            string nameFile = "Name";

            foreach (var file in files)
            {
                nameFile = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Millisecond.ToString();

                if (file.FileName.Contains(".jpg"))
                    nameFile += ".jpg";
                else if (file.FileName.Contains(".gif"))
                    nameFile += ".gif";
                else if (file.FileName.Contains(".png"))
                    nameFile += ".png";
                else if (file.FileName.Contains(".pdf"))
                    nameFile += ".pdf";
                else if (file.FileName.Contains(".xlsx"))
                    nameFile += ".xlsx";
                else if (file.FileName.Contains(".txt"))
                    nameFile += ".txt";
                else
                    nameFile += ".tmp";

                pathFileEnd = _appEnvironment.WebRootPath + "\\files\\" + nameFile;
                if (!System.IO.File.Exists(pathFileEnd))
                {
                    try
                    {
                        using (var stream = new FileStream(pathFileEnd, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    catch
                    {
                        ViewData["Erro"] = "Error: Sem permissão de acesso!";
                        return View(ViewData);
                    }
                }
                else
                {
                    ViewData["Erro"] = "Error(duplicity): Tente novamente!";
                    return View(ViewData);
                }
            }
            if (files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }
            else
            {
                await _importDataService.InsertDataAsync(importDataFormViewModel, pathFileEnd, nameFile, sizeFiles);
                var period = await _periodService.FindAllAsync();
                var viewModel = new ImportDataFormViewModel { Periods = period };
                ViewData["Resultado"] = $"{files.Count} arquivo foi enviado ao servidor, ";
                ViewData["Resultados"] = $"Com tamanho total de : {sizeFiles} KBytes.";
                return View(viewModel);
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