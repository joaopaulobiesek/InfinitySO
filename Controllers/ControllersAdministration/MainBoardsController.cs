﻿using System;
using System.Threading.Tasks;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersAdministration
{
    [Authorize(Policy = "AdministrationMainBoard")]
    public class MainBoardsController : Controller
    {
        private readonly MainBoardService _mainBoardService;

        public MainBoardsController(MainBoardService mainBoardService)
        {
            _mainBoardService = mainBoardService;
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
        public async Task<IActionResult> Create(MainBoard mainBoard)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string cpf = mainBoard.CPF;
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            var obj = await _mainBoardService.FindByCPFAsync(cpf);
            if (obj == null)
            {
                await _mainBoardService.InsertCreateAsync(mainBoard);
                return RedirectToAction(nameof(Create));
            }
            else
            {
                ViewData["ResultCadastroErro"] = "CPF já cadastrado!";
                return View("Create", mainBoard);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MainBoardFormViewModel mainBoardFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string cpf = mainBoardFormViewModel.MainBoard.CPF;
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            var obj = await _mainBoardService.FindByCPFAsync(cpf);
            if (obj == null)
            {
                await _mainBoardService.InsertAsync(mainBoardFormViewModel);
                return RedirectToAction(nameof(Register));
            }
            else
            {
                ViewData["ResultCadastroErro"] = "CPF já cadastrado!";
                return View("Register", mainBoardFormViewModel);
            }
        }
    }
}