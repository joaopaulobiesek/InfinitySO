using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using InfinitySO.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InfinitySO.Models.ModelsUserDataLogin;
using Microsoft.AspNetCore.Mvc;
using InfinitySO.Services.ServicesStudent;
using InfinitySO.Services.ServicesUserDataLogin;
using InfinitySO.Services.ServicesSystem;
using InfinitySO.Services.ServicesEmployee;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using InfinitySO.Services.ServicesPatrimony;

namespace InfinitySO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=InfinitySO;User Id=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddRazorPagesOptions(options =>
               {
                   //options.AllowAreas = true;
                   options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
                   options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                   options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
               });

            services.AddAuthorization(options =>
            {
                //Start ControllersAdministration
                options.AddPolicy("AdministrationAddress", policy => policy.RequireClaim("Address", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationAddress
                options.AddPolicy("AdministrationAddressCreate", policy => policy.RequireClaim("AddressCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationAddressEdit", policy => policy.RequireClaim("AddressEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationAddressDelete", policy => policy.RequireClaim("AddressDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationAddress
                options.AddPolicy("AdministrationCategory", policy => policy.RequireClaim("Category", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationCategory
                options.AddPolicy("AdministrationCategoryCreate", policy => policy.RequireClaim("CategoryCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationCategoryEdit", policy => policy.RequireClaim("CategoryEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationCategoryDelete", policy => policy.RequireClaim("CategoryDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationCategory
                options.AddPolicy("AdministrationCompany", policy => policy.RequireClaim("Company", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationCompany
                options.AddPolicy("AdministrationCompanyCreate", policy => policy.RequireClaim("CompanyCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationCompanyEdit", policy => policy.RequireClaim("CompanyEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationCompanyDelete", policy => policy.RequireClaim("CompanyDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationCompany
                options.AddPolicy("AdministrationDepartment", policy => policy.RequireClaim("Department", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationDepartment
                options.AddPolicy("AdministrationDepartmentCreate", policy => policy.RequireClaim("DepartmentCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationDepartmentEdit", policy => policy.RequireClaim("DepartmentEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationDepartmentDelete", policy => policy.RequireClaim("DepartmentDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationDepartment
                options.AddPolicy("AdministrationMainBoard", policy => policy.RequireClaim("MainBoard", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationMainBoard
                options.AddPolicy("AdministrationMainBoardCreate", policy => policy.RequireClaim("MainBoardCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationMainBoardEdit", policy => policy.RequireClaim("MainBoardEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationMainBoardDelete", policy => policy.RequireClaim("MainBoardDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationMainBoard
                options.AddPolicy("AdministrationPlace", policy => policy.RequireClaim("Place", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationPlace
                options.AddPolicy("AdministrationPlaceCreate", policy => policy.RequireClaim("PlaceCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationPlaceEdit", policy => policy.RequireClaim("PlaceEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationPlaceDelete", policy => policy.RequireClaim("PlaceDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationPlace
                options.AddPolicy("AdministrationSector", policy => policy.RequireClaim("Sector", "1", "2", "3", "4", "5"));
                //Start ControllersAdministrationSector
                options.AddPolicy("AdministrationSectorCreate", policy => policy.RequireClaim("SectorCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationSectorEdit", policy => policy.RequireClaim("SectorEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministrationSectorDelete", policy => policy.RequireClaim("SectorDelete", "1", "2", "3", "4", "5"));
                //End ControllersAdministrationSector
                //End ControllersAdministration

                //Start ControllersEmployee
                options.AddPolicy("EmployeeEmployee", policy => policy.RequireClaim("Employee", "1", "2", "3", "4", "5"));
                //Start ControllersEmployeeEmployee
                options.AddPolicy("EmployeeEmployeeCreate", policy => policy.RequireClaim("EmployeeCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeEmployeeEdit", policy => policy.RequireClaim("EmployeeEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeEmployeeDelete", policy => policy.RequireClaim("EmployeeDelete", "1", "2", "3", "4", "5"));
                //End ControllersEmployeeEmployee
                options.AddPolicy("EmployeeJourney", policy => policy.RequireClaim("Journey", "1", "2", "3", "4", "5"));
                //Start ControllersEmployeeJourney
                options.AddPolicy("EmployeeJourneyCreate", policy => policy.RequireClaim("JourneyCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeJourneyEdit", policy => policy.RequireClaim("JourneyEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeJourneyDelete", policy => policy.RequireClaim("JourneyDelete", "1", "2", "3", "4", "5"));
                //End ControllersEmployeeJourney
                options.AddPolicy("EmployeeScale", policy => policy.RequireClaim("Scale", "1", "2", "3", "4", "5"));
                //Start ControllersEmployeeScale
                options.AddPolicy("EmployeeScaleCreate", policy => policy.RequireClaim("ScaleCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeScaleEdit", policy => policy.RequireClaim("ScaleEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeScaleDelete", policy => policy.RequireClaim("ScaleDelete", "1", "2", "3", "4", "5"));
                //End ControllersEmployeeScale
                options.AddPolicy("EmployeeTimePoint", policy => policy.RequireClaim("TimePoint", "1", "2", "3", "4", "5"));
                //Start ControllersEmployeeTimePoint
                options.AddPolicy("EmployeeTimePointCreate", policy => policy.RequireClaim("TimePointCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeTimePointEdit", policy => policy.RequireClaim("TimePointEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("EmployeeTimePointDelete", policy => policy.RequireClaim("TimePointDelete", "1", "2", "3", "4", "5"));
                //End ControllersEmployeeTimePoint
                //End ControllersEmployee

                //Start ControllersPatrimony
                options.AddPolicy("PatrimonySubCategory", policy => policy.RequireClaim("SubCategory", "1", "2", "3", "4", "5"));
                //Start ControllersPatrimonySubCategory
                options.AddPolicy("PatrimonySubCategoryCreate", policy => policy.RequireClaim("SubCategoryCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonySubCategoryEdit", policy => policy.RequireClaim("SubCategoryEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonySubCategoryDelete", policy => policy.RequireClaim("SubCategoryDelete", "1", "2", "3", "4", "5"));
                //End ControllersPatrimonySubCategory
                options.AddPolicy("PatrimonyPatrimonyKey", policy => policy.RequireClaim("PatrimonyKey", "1", "2", "3", "4", "5"));
                //Start ControllersPatrimonyPatrimonyKey
                options.AddPolicy("PatrimonyPatrimonyKeyCreate", policy => policy.RequireClaim("PatrimonyKeyCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyKeyEdit", policy => policy.RequireClaim("PatrimonyKeyEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyKeyDelete", policy => policy.RequireClaim("PatrimonyKeyDelete", "1", "2", "3", "4", "5"));
                //End ControllersPatrimonyPatrimonyKey
                options.AddPolicy("PatrimonyPatrimonyKeyDescription", policy => policy.RequireClaim("PatrimonyKeyDescription", "1", "2", "3", "4", "5"));
                //Start ControllersPatrimonyPatrimonyKeyDescription
                options.AddPolicy("PatrimonyPatrimonyKeyDescriptionCreate", policy => policy.RequireClaim("PatrimonyKeyDescriptionCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyKeyDescriptionEdit", policy => policy.RequireClaim("PatrimonyKeyDescriptionEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyKeyDescriptionDelete", policy => policy.RequireClaim("PatrimonyKeyDescriptionDelete", "1", "2", "3", "4", "5"));
                //End ControllersPatrimonyPatrimonyKeyDescription
                options.AddPolicy("PatrimonyPatrimony", policy => policy.RequireClaim("Patrimony", "1", "2", "3", "4", "5"));
                //Start ControllersPatrimonyPatrimony
                options.AddPolicy("PatrimonyPatrimonyCreate", policy => policy.RequireClaim("PatrimonyCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyEdit", policy => policy.RequireClaim("PatrimonyEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("PatrimonyPatrimonyDelete", policy => policy.RequireClaim("PatrimonyDelete", "1", "2", "3", "4", "5"));
                //End ControllersPatrimonyPatrimony
                //End ControllersPatrimony

                //Start ControllersStudent
                options.AddPolicy("StudentBilletValue", policy => policy.RequireClaim("BilletValue", "1", "2", "3", "4", "5"));
                //Start ControllersStudentBilletValue
                options.AddPolicy("StudentBilletValueCreate", policy => policy.RequireClaim("BilletValueCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentBilletValueEdit", policy => policy.RequireClaim("BilletValueEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentBilletValueDelete", policy => policy.RequireClaim("BilletValueDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentBilletValue
                options.AddPolicy("StudentCourse", policy => policy.RequireClaim("Course", "1", "2", "3", "4", "5"));
                //Start ControllersStudentCourse
                options.AddPolicy("StudentCourseCreate", policy => policy.RequireClaim("CourseCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentCourseEdit", policy => policy.RequireClaim("CourseEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentCourseDelete", policy => policy.RequireClaim("CourseDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentCourse
                options.AddPolicy("StudentPeriod", policy => policy.RequireClaim("Period", "1", "2", "3", "4", "5"));
                //Start ControllersStudentPeriod
                options.AddPolicy("StudentPeriodCreate", policy => policy.RequireClaim("PeriodCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentPeriodEdit", policy => policy.RequireClaim("PeriodEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentPeriodDelete", policy => policy.RequireClaim("PeriodDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentPeriod
                options.AddPolicy("StudentSemester", policy => policy.RequireClaim("Semester", "1", "2", "3", "4", "5"));
                //Start ControllersStudentSemester
                options.AddPolicy("StudentSemesterCreate", policy => policy.RequireClaim("SemesterCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentSemesterEdit", policy => policy.RequireClaim("SemesterEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentSemesterDelete", policy => policy.RequireClaim("SemesterDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentSemester
                options.AddPolicy("StudentStudentFinancial", policy => policy.RequireClaim("StudentFinancial", "1", "2", "3", "4", "5"));
                //Start ControllersStudentStudentFinancial
                options.AddPolicy("StudentStudentFinancialCreate", policy => policy.RequireClaim("StudentFinancialCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentStudentFinancialEdit", policy => policy.RequireClaim("StudentFinancialEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentStudentFinancialDelete", policy => policy.RequireClaim("StudentFinancialDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentStudentFinancial
                options.AddPolicy("StudentStudent", policy => policy.RequireClaim("Student", "1", "2", "3", "4", "5"));
                //Start ControllersStudentStudent
                options.AddPolicy("StudentStudentCreate", policy => policy.RequireClaim("StudentCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentStudentEdit", policy => policy.RequireClaim("StudentEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("StudentStudentDelete", policy => policy.RequireClaim("StudentDelete", "1", "2", "3", "4", "5"));
                //End ControllersStudentStudent
                //End ControllersStudent

                //Start ControllersUserDataLogin
                options.AddPolicy("UserDataLoginUserDataLogin", policy => policy.RequireClaim("UserDataLogin", "1", "2", "3", "4", "5"));
                options.AddPolicy("UserDataLoginUserDataLoginCreate", policy => policy.RequireClaim("UserDataLoginCreate", "1", "2", "3", "4", "5"));
                options.AddPolicy("UserDataLoginUserDataLoginEdit", policy => policy.RequireClaim("UserDataLoginEdit", "1", "2", "3", "4", "5"));
                options.AddPolicy("UserDataLoginUserDataLoginDelete", policy => policy.RequireClaim("UserDataLoginDelete", "1", "2", "3", "4", "5"));
                //End ControllersUserDataLogin

                //Start ControllersHome
                options.AddPolicy("HomeHome", policy => policy.RequireClaim("Home", "1", "2", "3", "4", "5"));
                //End ControllersHome

                //Start ControllersAdministratorSystem
                options.AddPolicy("AdministratorSystemAdmin", policy => policy.RequireClaim("Admin", "1", "2", "3", "4", "5"));
                options.AddPolicy("AdministratorSystemFullAcess", policy => policy.RequireClaim("FullAcess", "1", "2", "3", "4", "5"));
                //End ControllersAdministratorSystem
            });

            //Inicilizar Injeção de dependencias
            services.AddScoped<SeedingService>();

            //Start Administration
            services.AddScoped<AddressService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<ImportDataService>();
            services.AddScoped<MainBoardService>();
            services.AddScoped<PlaceService>();
            services.AddScoped<SectorService>();
            //End Administration           

            //Start Employee
            services.AddScoped<EmployeeService>();
            services.AddScoped<JourneyService>();
            services.AddScoped<ScaleService>();
            services.AddScoped<TimePointService>();
            //End Employee

            //Start Patrimony
            services.AddScoped<HistoricPatrimonyService>();
            services.AddScoped<PatrimonyService>();
            services.AddScoped<ProductService>();
            //End Patrimony

            //Start System
            services.AddScoped<DownloadFileService>();
            services.AddScoped<SystemControllerService>();
            services.AddScoped<SystemSubControllerService>();
            //End System

            //Start Student
            services.AddScoped<BilletValueService>();
            services.AddScoped<CourseService>();
            services.AddScoped<PeriodService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<StudentFinancialService>();
            services.AddScoped<StudentService>();
            //End Student

            //Start UserDataLogin
            services.AddScoped<UserDataLoginService>();
            //End UserDataLogin
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var enUS = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };

            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
