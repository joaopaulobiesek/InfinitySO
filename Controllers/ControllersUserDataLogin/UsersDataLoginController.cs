using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InfinitySO.Models.Claims;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ModelsUserDataLogin;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.ServicesAdministration;
using InfinitySO.Services.ServicesSystem;
using InfinitySO.Services.ServicesUserDataLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InfinitySO.Controllers.ControllersUserDataLogin
{
    [Authorize(Policy = "UserDataLoginUserDataLogin")]
    public class UsersDataLoginController : Controller
    {
        private readonly UserDataLoginService _userDataLoginService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MainBoardService _mainBoardService;
        private readonly SystemControllerService _systemControllerService;
        private readonly SystemSubControllerService _systemSubControllerService;

        public UsersDataLoginController(UserDataLoginService userDataLoginService, UserManager<ApplicationUser> userManager, MainBoardService mainBoardService, SystemControllerService systemControllerService, SystemSubControllerService systemSubControllerService)
        {
            _userDataLoginService = userDataLoginService;
            _userManager = userManager;
            _mainBoardService = mainBoardService;
            _systemControllerService = systemControllerService;
            _systemSubControllerService = systemSubControllerService;
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

        public async Task<IActionResult> Index()
        {
            var userDataLogins = await _userDataLoginService.FindAllAppAsync();
            var viewModel = new ApplicationUser { ApplicationUsers = userDataLogins };
            return View(viewModel);
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
        public async Task<IActionResult> Create(UserDataLogin userDataLogin, string searchCPF)
        {
            var mainBoard = await _mainBoardService.FindAllAsync();
            var systemController = await _systemControllerService.FindAllAsync();
            var systemSubController = await _systemSubControllerService.FindAllAsync();
            var viewModel = new UserDataLogin { MainBoards = mainBoard, SystemControllers = systemController, SystemSubControllers = systemSubController };
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
                    var users = await _userDataLoginService.FindByIdAsync(mainBoards.Id);
                    if (users == null)
                    {
                        await _userDataLoginService.InsertAsync(userDataLogin, mainBoards);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["Error"] = "Este Usuário já possui login!";
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        { // https://www.youtube.com/watch?v=5XA4Z-SOif8

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var existingUserClaims = await _userManager.GetClaimsAsync(user);
            var viewModel = new UserClaimsFormViewModel { UserId = id };

            foreach (Claim claim in MainClaim.MainClaims)
            {
                if (claim.Type != "Home" && claim.Type != "Admin" && claim.Type != "FullAcess")
                {
                    string NameClaim = "";
                    switch (claim.Type)
                    {
                        case "MainBoard": NameClaim = "Cadastro Principal"; break;
                        case "MainBoardEdit": NameClaim = "Editar"; break;
                        case "MainBoardDelete": NameClaim = "Deletar"; break;
                        case "Category": NameClaim = "Espaço do Local"; break;
                        case "CategoryEdit": NameClaim = "Editar"; break;
                        case "CategoryDelete": NameClaim = "Deletar"; break;
                        case "Place": NameClaim = "Cadastro Local"; break;
                        case "PlaceEdit": NameClaim = "Editar"; break;
                        case "PlaceDelete": NameClaim = "Deletar"; break;
                        case "Company": NameClaim = "Empresa"; break;
                        case "CompanyEdit": NameClaim = "Editar"; break;
                        case "CompanyDelete": NameClaim = "Deletar"; break;
                        case "Supply": NameClaim = "Suprimento"; break;
                        case "SupplyEdit": NameClaim = "Editar"; break;
                        case "SupplyDelete": NameClaim = "Deletar"; break;
                        case "Certificate": NameClaim = "Certificado"; break;
                        case "CertificateEdit": NameClaim = "Editar"; break;
                        case "CertificateDelete": NameClaim = "Deletar"; break;
                        case "Employee": NameClaim = "Funcionario"; break;
                        case "EmployeeEdit": NameClaim = "Editar"; break;
                        case "EmployeeDelete": NameClaim = "Deletar"; break;
                        case "Journey": NameClaim = "Jornada"; break;
                        case "JourneyEdit": NameClaim = "Editar"; break;
                        case "JourneyDelete": NameClaim = "Deletar"; break;
                        case "Scale": NameClaim = "Escala"; break;
                        case "ScaleEdit": NameClaim = "Editar"; break;
                        case "ScaleDelete": NameClaim = "Deletar"; break;
                        case "TimePoint": NameClaim = "Ponto"; break;
                        case "Patrimony": NameClaim = "Patrimonio"; break;
                        case "PatrimonyEdit": NameClaim = "Editar"; break;
                        case "PatrimonyDelete": NameClaim = "Deletar"; break;
                        case "StudentFinancial": NameClaim = "Financeiro Estudantil"; break;
                        case "StudentFinancialEdit": NameClaim = "Editar"; break;
                        case "StudentFinancialDelete": NameClaim = "Deletar"; break;
                        case "Student": NameClaim = "Estudante"; break;
                        case "StudentEdit": NameClaim = "Editar"; break;
                        case "StudentDelete": NameClaim = "Deletar"; break;
                        case "UserDataLogin": NameClaim = "Cadastrar Acesso"; break;
                        case "UserDataLoginEdit": NameClaim = "Editar"; break;
                        case "UserDataLoginDelete": NameClaim = "Deletar"; break;
                    }
                    UserClaim userClaim = new UserClaim
                    {
                        ClaimType = claim.Type,
                        ClaimName = NameClaim
                    };
                    if (existingUserClaims.Any(c => c.Type == claim.Type))
                    {
                        userClaim.IsSelected = true;
                    }
                    viewModel.Cliams.Add(userClaim);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserClaimsFormViewModel userClaimsFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var users = await _userManager.FindByIdAsync(userClaimsFormViewModel.UserId);
                var existingUserClaims = await _userManager.GetClaimsAsync(users);
                var viewModel = new UserClaimsFormViewModel { UserId = userClaimsFormViewModel.UserId };
                foreach (Claim claim in MainClaim.MainClaims)
                {
                    UserClaim userClaim = new UserClaim
                    {
                        ClaimType = claim.Type
                    };
                    if (existingUserClaims.Any(c => c.Type == claim.Type))
                    {
                        userClaim.IsSelected = true;
                    }
                    viewModel.Cliams.Add(userClaim);
                }
                return View(viewModel);
            }
            try
            {
                await _userDataLoginService.UpdateAsync(userClaimsFormViewModel);
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