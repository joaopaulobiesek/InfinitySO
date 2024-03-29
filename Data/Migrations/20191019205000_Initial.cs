﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfinitySO.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateName = table.Column<string>(maxLength: 60, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    StateRegistration = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Cell = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Soon = table.Column<string>(nullable: true),
                    Creation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Duration = table.Column<string>(maxLength: 5, nullable: false),
                    Input1 = table.Column<string>(maxLength: 5, nullable: true),
                    Input2 = table.Column<string>(maxLength: 5, nullable: true),
                    Input3 = table.Column<string>(maxLength: 5, nullable: true),
                    Input4 = table.Column<string>(maxLength: 5, nullable: true),
                    Input5 = table.Column<string>(maxLength: 5, nullable: true),
                    Input6 = table.Column<string>(maxLength: 5, nullable: true),
                    Output1 = table.Column<string>(maxLength: 5, nullable: true),
                    Output2 = table.Column<string>(maxLength: 5, nullable: true),
                    Output3 = table.Column<string>(maxLength: 5, nullable: true),
                    Output4 = table.Column<string>(maxLength: 5, nullable: true),
                    Output5 = table.Column<string>(maxLength: 5, nullable: true),
                    Output6 = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    CPF = table.Column<string>(maxLength: 20, nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Cell = table.Column<string>(maxLength: 15, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Creation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureType = table.Column<int>(nullable: false),
                    ProductCategory = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ValueMeasure = table.Column<double>(nullable: false),
                    MinimumOrderQuantity = table.Column<double>(nullable: false),
                    ActiveSupply = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemController",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameController = table.Column<string>(nullable: true),
                    NameClaim = table.Column<string>(nullable: true),
                    ValueClaim = table.Column<int>(nullable: false),
                    IsCheck = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemController", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    NameCourse = table.Column<string>(nullable: true),
                    NameSignature = table.Column<string>(nullable: true),
                    NameCPF = table.Column<string>(maxLength: 20, nullable: false),
                    Hour = table.Column<string>(maxLength: 4, nullable: true),
                    Value = table.Column<double>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(type: "date", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateCourse_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Initials = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sector_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBoardId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    State = table.Column<string>(maxLength: 20, nullable: false),
                    CEP = table.Column<string>(maxLength: 12, nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 30, nullable: false),
                    Street = table.Column<string>(maxLength: 60, nullable: false),
                    Number = table.Column<string>(maxLength: 5, nullable: false),
                    Complement = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MainBoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDataLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBoardId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordUser = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDataLogin_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScaleFormatting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JourneyId = table.Column<int>(nullable: false),
                    ScaleId = table.Column<int>(nullable: false),
                    Week = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleFormatting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScaleFormatting_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScaleFormatting_Scale_ScaleId",
                        column: x => x.ScaleId,
                        principalTable: "Scale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CodPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Period_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemSubController",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemControllerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameSubController = table.Column<string>(nullable: true),
                    NameClaim = table.Column<string>(nullable: true),
                    ValueClaim = table.Column<int>(nullable: false),
                    IsCheck = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSubController", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemSubController_SystemController_SystemControllerId",
                        column: x => x.SystemControllerId,
                        principalTable: "SystemController",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBoardId = table.Column<int>(nullable: false),
                    CertificateCourseId = table.Column<int>(nullable: false),
                    Pay = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_CertificateCourse_CertificateCourseId",
                        column: x => x.CertificateCourseId,
                        principalTable: "CertificateCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificate_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProgrammatic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateCourseId = table.Column<int>(nullable: false),
                    Cod = table.Column<int>(nullable: false),
                    ProgrammaticContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateProgrammatic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateProgrammatic_CertificateCourse_CertificateCourseId",
                        column: x => x.CertificateCourseId,
                        principalTable: "CertificateCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(nullable: false),
                    AmountPeople = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patrimony",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    KeyPatrimony = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    DescriptionProduct = table.Column<string>(nullable: true),
                    DateBuy = table.Column<DateTime>(type: "date", nullable: false),
                    NextMaintenanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimony_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patrimony_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBoardId = table.Column<int>(nullable: false),
                    SectorId = table.Column<int>(nullable: false),
                    ScaleId = table.Column<int>(nullable: false),
                    Admission = table.Column<DateTime>(type: "date", nullable: false),
                    Resignation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Scale_ScaleId",
                        column: x => x.ScaleId,
                        principalTable: "Scale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeFile = table.Column<int>(nullable: false),
                    CommandExecuted = table.Column<int>(nullable: false),
                    PeriodId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameFile = table.Column<string>(nullable: true),
                    PageNumbers = table.Column<int>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    DateUpload = table.Column<DateTime>(type: "date", nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadFile_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBoardId = table.Column<int>(nullable: false),
                    PeriodId = table.Column<int>(nullable: false),
                    EAD = table.Column<string>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    NumberPeriod = table.Column<string>(nullable: false),
                    StudentRegistration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_MainBoard_MainBoardId",
                        column: x => x.MainBoardId,
                        principalTable: "MainBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricPatrimony",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowPatrimony = table.Column<int>(nullable: false),
                    PatrimonyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2147483647, nullable: false),
                    DateDescription = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricPatrimony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricPatrimony_Patrimony_PatrimonyId",
                        column: x => x.PatrimonyId,
                        principalTable: "Patrimony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyAdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    QuantityAdded = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyAdd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyAdd_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyAdd_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyWithdrawal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountWithdrawn = table.Column<double>(nullable: false),
                    WithDrawalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyWithdrawal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyWithdrawal_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyWithdrawal_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimePoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Input1 = table.Column<DateTime>(nullable: false),
                    Input2 = table.Column<DateTime>(nullable: false),
                    Input3 = table.Column<DateTime>(nullable: false),
                    Input4 = table.Column<DateTime>(nullable: false),
                    Input5 = table.Column<DateTime>(nullable: false),
                    Input6 = table.Column<DateTime>(nullable: false),
                    Output1 = table.Column<DateTime>(nullable: false),
                    Output2 = table.Column<DateTime>(nullable: false),
                    Output3 = table.Column<DateTime>(nullable: false),
                    Output4 = table.Column<DateTime>(nullable: false),
                    Output5 = table.Column<DateTime>(nullable: false),
                    Output6 = table.Column<DateTime>(nullable: false),
                    DateDay = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimePoint_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentFinancial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    OpenValue = table.Column<double>(nullable: false),
                    DateNegotiation = table.Column<DateTime>(type: "date", nullable: false),
                    DateDueBillet = table.Column<DateTime>(type: "date", nullable: false),
                    StudentFinancialNegotiation = table.Column<int>(nullable: false),
                    StudentFinanceInstallment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFinancial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFinancial_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BilletValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFinancialId = table.Column<int>(nullable: false),
                    DateDue = table.Column<DateTime>(type: "date", nullable: false),
                    ValueBillet = table.Column<double>(nullable: false),
                    BilletPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilletValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BilletValue_StudentFinancial_StudentFinancialId",
                        column: x => x.StudentFinancialId,
                        principalTable: "StudentFinancial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_MainBoardId",
                table: "Address",
                column: "MainBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MainBoardId",
                table: "AspNetUsers",
                column: "MainBoardId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BilletValue_StudentFinancialId",
                table: "BilletValue",
                column: "StudentFinancialId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PlaceId",
                table: "Category",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CertificateCourseId",
                table: "Certificate",
                column: "CertificateCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_MainBoardId",
                table: "Certificate",
                column: "MainBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateCourse_CompanyId",
                table: "CertificateCourse",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProgrammatic_CertificateCourseId",
                table: "CertificateProgrammatic",
                column: "CertificateCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadFile_PeriodId",
                table: "DownloadFile",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MainBoardId",
                table: "Employee",
                column: "MainBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ScaleId",
                table: "Employee",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SectorId",
                table: "Employee",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricPatrimony_PatrimonyId",
                table: "HistoricPatrimony",
                column: "PatrimonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_PlaceId",
                table: "Patrimony",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_ProductId",
                table: "Patrimony",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_CourseId",
                table: "Period",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_SemesterId",
                table: "Period",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_CompanyId",
                table: "Place",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleFormatting_JourneyId",
                table: "ScaleFormatting",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleFormatting_ScaleId",
                table: "ScaleFormatting",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_DepartmentId",
                table: "Sector",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MainBoardId",
                table: "Student",
                column: "MainBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PeriodId",
                table: "Student",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFinancial_StudentId",
                table: "StudentFinancial",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyAdd_EmployeeId",
                table: "SupplyAdd",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyAdd_SupplyId",
                table: "SupplyAdd",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyWithdrawal_EmployeeId",
                table: "SupplyWithdrawal",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyWithdrawal_SupplyId",
                table: "SupplyWithdrawal",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSubController_SystemControllerId",
                table: "SystemSubController",
                column: "SystemControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimePoint_EmployeeId",
                table: "TimePoint",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataLogin_MainBoardId",
                table: "UserDataLogin",
                column: "MainBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BilletValue");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "CertificateProgrammatic");

            migrationBuilder.DropTable(
                name: "DownloadFile");

            migrationBuilder.DropTable(
                name: "HistoricPatrimony");

            migrationBuilder.DropTable(
                name: "ScaleFormatting");

            migrationBuilder.DropTable(
                name: "SupplyAdd");

            migrationBuilder.DropTable(
                name: "SupplyWithdrawal");

            migrationBuilder.DropTable(
                name: "SystemSubController");

            migrationBuilder.DropTable(
                name: "TimePoint");

            migrationBuilder.DropTable(
                name: "UserDataLogin");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StudentFinancial");

            migrationBuilder.DropTable(
                name: "CertificateCourse");

            migrationBuilder.DropTable(
                name: "Patrimony");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "SystemController");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Scale");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "MainBoard");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
