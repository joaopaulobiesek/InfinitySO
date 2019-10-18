using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using InfinitySO.Models.ModelsUserDataLogin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using System.Security.Claims;

namespace InfinitySO.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly SeedingService _seedingService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDbContext context, SeedingService seedingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _seedingService = seedingService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            await _seedingService.Seed();
            if (_context.MainBoard.Any())
            {
                return Page();  // DB has been seeded
            }

            MainBoard m1 = new MainBoard { Name = "Administrator", LastName = "Local", CPF = "000.000.000-00", RG = "00.000", Phone = "(XX)xxxx-xxxx", Cell = "(XX)x xxxx-xxxx", BirthDate = new DateTime(1990, 01, 01), Email = "admin@admin.com", Creation = new DateTime(2019, 08, 21) };

            ApplicationUser app = new ApplicationUser { MainBoard = m1, UserName = "admin@admin.com", Email = "admin@admin.com" };

            UserDataLogin l1 = new UserDataLogin { MainBoard = m1, UserName = "admin@admin.com", PasswordUser = "K1l2X3c4*1" };

            await _context.MainBoard.AddAsync(m1);

            await _context.UserDataLogin.AddAsync(l1);

            await _userManager.CreateAsync(app, "K1l2X3c4*1");
            await _userManager.AddClaimAsync(app, new Claim("Home", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Admin", "5"));
            await _userManager.AddClaimAsync(app, new Claim("FullAcess", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Address", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Category", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Company", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Department", "5"));
            await _userManager.AddClaimAsync(app, new Claim("MainBoard", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Place", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Sector", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Supply", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyAdd", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyWithdrawal", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Certificate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateCourse", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateProgrammatic", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Employee", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Journey", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Scale", "5"));
            await _userManager.AddClaimAsync(app, new Claim("TimePoint", "5"));
            await _userManager.AddClaimAsync(app, new Claim("HistoricPatrimony", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Patrimony", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Product", "5"));
            await _userManager.AddClaimAsync(app, new Claim("BilletValue", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Course", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Period", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Semester", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentFinancial", "5"));
            await _userManager.AddClaimAsync(app, new Claim("Student", "5"));
            await _userManager.AddClaimAsync(app, new Claim("UserDataLogin", "5"));
            await _userManager.AddClaimAsync(app, new Claim("AddressCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("AddressEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("AddressDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CategoryCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CategoryEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CategoryDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CompanyCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CompanyEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CompanyDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("DepartmentCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("DepartmentEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("DepartmentDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("MainBoardCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("MainBoardEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("MainBoardDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PlaceCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PlaceEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PlaceDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SectorCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SectorEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SectorDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyAddCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyAddEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyAddDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyWithdrawalCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyWithdrawalEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SupplyWithdrawalDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateCourseCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateCourseEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateCourseDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateProgrammaticCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateProgrammaticEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CertificateProgrammaticDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("EmployeeCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("EmployeeEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("EmployeeDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("JourneyCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("JourneyEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("JourneyDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ScaleCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ScaleEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ScaleDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("TimePointCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("TimePointEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("TimePointDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("HistoricPatrimonyCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("HistoricPatrimonyEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("HistoricPatrimonyDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PatrimonyCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PatrimonyEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PatrimonyDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ProductCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ProductEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("ProductDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("BilletValueCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("BilletValueEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("BilletValueDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CourseCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CourseEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("CourseDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PeriodCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PeriodEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("PeriodDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SemesterCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SemesterEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("SemesterDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentFinancialCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentFinancialEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentFinancialDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("StudentDelete", "5"));
            await _userManager.AddClaimAsync(app, new Claim("UserDataLoginCreate", "5"));
            await _userManager.AddClaimAsync(app, new Claim("UserDataLoginEdit", "5"));
            await _userManager.AddClaimAsync(app, new Claim("UserDataLoginDelete", "5"));

            await _context.SaveChangesAsync();
            return Page();
            /*  returnUrl = returnUrl ?? Url.Content("~/");
              ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
              if (ModelState.IsValid)
              {
                  var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                  var result = await _userManager.CreateAsync(user, Input.Password);
                  if (result.Succeeded)
                  {
                      _logger.LogInformation("User created a new account with password.");

                      var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                      code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                      var callbackUrl = Url.Page(
                          "/Account/ConfirmEmail",
                          pageHandler: null,
                          values: new { area = "Identity", userId = user.Id, code = code },
                          protocol: Request.Scheme);

                      await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                          $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                      if (_userManager.Options.SignIn.RequireConfirmedAccount)
                      {
                          return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                      }
                      else
                      {
                          await _signInManager.SignInAsync(user, isPersistent: false);
                          return LocalRedirect(returnUrl);
                      }
                  }
                  foreach (var error in result.Errors)
                  {
                      ModelState.AddModelError(string.Empty, error.Description);
                  }
              }

              // If we got this far, something failed, redisplay form
              return Page();*/
        }
    }
}
