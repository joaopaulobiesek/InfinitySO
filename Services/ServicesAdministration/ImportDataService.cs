using InfinitySO.Data;
using InfinitySO.Models.Enums;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ViewModels;
using InfinitySO.Models.ModelsSystem;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Services.ServicesStudent;
using InfinitySO.Models.ModelsAdministration;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InfinitySO.Services.ServicesAdministration
{
    public class ImportDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly MainBoardService _mainBoardService;
        private readonly PeriodService _periodService;
        private readonly StudentService _studentService;

        public ImportDataService(ApplicationDbContext context, MainBoardService mainBoardService, StudentService studentService, PeriodService periodService)
        {
            _context = context;
            _mainBoardService = mainBoardService;
            _studentService = studentService;
            _periodService = periodService;
        }

        public async Task InsertAsync(DownloadFile obj)
        {
            var pathEnd = obj.Path + obj.NameFile;
            var wb = new XLWorkbook(pathEnd);
            var planilha = wb.Worksheet(1);

            var linha = 2;
            while (true)
            {
                if (string.IsNullOrEmpty(planilha.Cell("C" + linha.ToString()).Value.ToString())) break;
                string NumberPeriodEAD = planilha.Cell("A" + linha.ToString()).Value.ToString().Substring(planilha.Cell("A" + linha.ToString()).Value.ToString().Length - 2, 2);
                string EAD = planilha.Cell("A" + linha.ToString()).Value.ToString().Remove(planilha.Cell("A" + linha.ToString()).Value.ToString().Length - 2);
                string cpf = planilha.Cell("B" + linha.ToString()).Value.ToString();
                string NameComplete = planilha.Cell("C" + linha.ToString()).Value.ToString();
                string email = planilha.Cell("D" + linha.ToString()).Value.ToString();
                string tel = planilha.Cell("E" + linha.ToString()).Value.ToString();
                string Situation = planilha.Cell("F" + linha.ToString()).Value.ToString();
                string Period = planilha.Cell("G" + linha.ToString()).Value.ToString();
                StudentRegistration SituationEnd;

                if (Situation == "Nao Efetuou Matric.")
                {
                    SituationEnd = StudentRegistration.DidNotRegistration;
                }
                else if (Situation == "Vestibular")
                {
                    SituationEnd = StudentRegistration.EntranceExam;
                }
                else if (Situation == "Matricula pré- confirmada")
                {
                    SituationEnd = StudentRegistration.Pre_ConfirmedRegistration;
                }
                else if (Situation == "Matricula Ativa")
                {
                    SituationEnd = StudentRegistration.ActiveRegistration;
                }
                else if (Situation == "Formando")
                {
                    SituationEnd = StudentRegistration.Forming;
                }
                else if (Situation == "Desistente")
                {
                    SituationEnd = StudentRegistration.Quitter;
                }
                else if (Situation == "Matricula Trancada")
                {
                    SituationEnd = StudentRegistration.LockedRegistration;
                }
                else if (Situation == "Matricula Cancelada")
                {
                    SituationEnd = StudentRegistration.RegistrationCanceled;
                }
                else
                {
                    SituationEnd = StudentRegistration.DidNotRegistration;
                }

                cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                var objec = await _mainBoardService.FindByCPFAsync(cpf);
                var obje2 = await _studentService.FindByEADAsync(EAD);
                var obje3 = await _periodService.FindByCodPeriodAsync(Period);

                if (objec == null && obje2 == null)
                {
                    string[] NameSplit = NameComplete.Split(' ');
                    string Name = "";
                    string LastName = "";
                    int count = 0;

                    foreach (var item in NameSplit)
                    {
                        count++;
                        if (count == 1)
                        {
                            Name = item;
                        }
                        else if (count == 2)
                        {
                            LastName = item;
                        }
                        else
                        {
                            LastName += " " + item;
                        }
                    }

                    if (obje3 != null)
                    {
                        MainBoard m1 = new MainBoard { Name = Name, LastName = LastName, CPF = cpf, RG = "00.000", Phone = "(XX)xxxx-xxxx", Cell = tel, BirthDate = new DateTime(1990, 01, 01), Email = email, Creation = new DateTime(2019, 08, 21) };
                        Student s1 = new Student { PeriodId = obje3.Id, MainBoard = m1, EAD = EAD, NumberPeriod = NumberPeriodEAD, Week = DayOfWeek.Friday, StudentRegistration = SituationEnd };
                        Address a1 = new Address { MainBoard = m1, CEP = "Nulo", City = "Nulo", State = "Nulo", Neighborhood = "Nulo", Street = "Nulo", Number = "Nulo", Complement = "Nulo" };
                        await _context.MainBoard.AddAsync(m1);
                        await _context.Address.AddAsync(a1);
                        await _context.Student.AddAsync(s1);
                    }
                    else
                    {
                        var obje4 = await _periodService.FindByCodPeriodAsync("CUR00");
                        MainBoard m1 = new MainBoard { Name = Name, LastName = LastName, CPF = cpf, RG = "00.000", Phone = "(XX)xxxx-xxxx", Cell = tel, BirthDate = new DateTime(1990, 01, 01), Email = email, Creation = new DateTime(2019, 08, 21) };
                        Student s1 = new Student { PeriodId = obje4.Id, MainBoard = m1, EAD = EAD, NumberPeriod = NumberPeriodEAD, Week = DayOfWeek.Friday, StudentRegistration = SituationEnd };
                        Address a1 = new Address { MainBoard = m1, CEP = "Nulo", City = "Nulo", State = "Nulo", Neighborhood = "Nulo", Street = "Nulo", Number = "Nulo", Complement = "Nulo" };
                        await _context.MainBoard.AddAsync(m1);
                        await _context.Address.AddAsync(a1);
                        await _context.Student.AddAsync(s1);
                    }
                    linha++;
                }
                else if (objec != null && obje2 == null)
                {
                    if (obje3 != null)
                    {
                        Student s1 = new Student { PeriodId = obje3.Id, MainBoardId = objec.Id, EAD = EAD, NumberPeriod = NumberPeriodEAD, Week = DayOfWeek.Friday, StudentRegistration = SituationEnd };
                        await _context.Student.AddAsync(s1);
                    }
                    else
                    {
                        var obje4 = await _periodService.FindByCodPeriodAsync("CUR00");
                        Student s1 = new Student { PeriodId = obje4.Id, MainBoardId = objec.Id, EAD = EAD, NumberPeriod = NumberPeriodEAD, Week = DayOfWeek.Friday, StudentRegistration = SituationEnd };
                        await _context.Student.AddAsync(s1);
                    }
                    linha++;
                }
                else if (objec != null && obje2 != null)
                {
                    if (obje3 != null)
                    {
                        _context.Entry(obje2).Property("PeriodId").CurrentValue = obje3.Id;
                        _context.Entry(obje2).Property("StudentRegistration").CurrentValue = SituationEnd;
                        _context.Entry(obje2).Property("NumberPeriod").CurrentValue = NumberPeriodEAD;
                    }
                    else
                    {
                        var obje4 = await _periodService.FindByCodPeriodAsync("CUR00");
                        _context.Entry(obje2).Property("PeriodId").CurrentValue = obje4.Id;
                        _context.Entry(obje2).Property("StudentRegistration").CurrentValue = SituationEnd;
                        _context.Entry(obje2).Property("NumberPeriod").CurrentValue = NumberPeriodEAD;
                    }
                    linha++;
                }
                else
                {
                    linha++;
                }
            }
             _context.Entry(obj).Property("CommandExecuted").CurrentValue = CommandExecuted.Executed;
            //obj.CommandExecuted = CommandExecuted.Executed; FUNCIONA aula udemy https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/learn/lecture/11595926#questions
            //https://docs.microsoft.com/pt-br/ef/ef6/saving/change-tracking/property-values
            await _context.SaveChangesAsync();
            wb.Dispose();
        }

        public async Task InsertDataAsync(ImportDataFormViewModel obj, string pathFile, string nameFile, long sizeFile)
        {
            string[] pathFileEnd = pathFile.Split(nameFile);
            DownloadFile df1 = new DownloadFile { Name = obj.DownloadFile.Name, NameFile = nameFile, Path = pathFileEnd[0], PageNumbers = obj.DownloadFile.PageNumbers, TypeFile = obj.DownloadFile.TypeFile, Size = sizeFile, DateUpload = DateTime.Now, CommandExecuted = CommandExecuted.NotExecuted };
            await _context.DownloadFile.AddAsync(df1);
            await _context.SaveChangesAsync();
        }
    }
}