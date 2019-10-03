using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsUserDataLogin;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesSystem;
using InfinitySO.Services.ServicesUserDataLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersUserDataLogin
{
    [Authorize(Policy = "UserDataLoginUserDataLogin")]
    public class UsersDataLoginController : Controller
    {
        private readonly UserDataLoginService _userDataLoginService;
        private readonly MainBoardService _mainBoardService;
        private readonly SystemControllerService _systemControllerService;
        private readonly SystemSubControllerService _systemSubControllerService;

        public UsersDataLoginController(UserDataLoginService userDataLoginService, MainBoardService mainBoardService, SystemControllerService systemControllerService, SystemSubControllerService systemSubControllerService)
        {
            _userDataLoginService = userDataLoginService;
            _mainBoardService = mainBoardService;
            _systemControllerService = systemControllerService;
            _systemSubControllerService = systemSubControllerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var mainBoard = await _mainBoardService.FindAllAsync();
            var systemController = await _systemControllerService.FindAllAsync();
            var systemSubController = await _systemSubControllerService.FindAllAsync();
            var viewModel = new UserDataLogin { MainBoards = mainBoard, SystemControllers = systemController, SystemSubControllers = systemSubController };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDataLogin userDataLogin)
        {
            if (!ModelState.IsValid)
            {
                var mainBoard = await _mainBoardService.FindAllAsync();
                var systemController = await _systemControllerService.FindAllAsync();
                var systemSubController = await _systemSubControllerService.FindAllAsync();
                var viewModel = new UserDataLogin { MainBoards = mainBoard, SystemControllers = systemController, SystemSubControllers = systemSubController };
                return View(viewModel);
            }
            await _userDataLoginService.InsertAsync(userDataLogin);
            return RedirectToAction(nameof(Create));
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