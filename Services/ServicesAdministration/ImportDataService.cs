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
        private readonly StudentService _studentService;

        public ImportDataService(ApplicationDbContext context, MainBoardService mainBoardService, StudentService studentService)
        {
            _context = context;
            _mainBoardService = mainBoardService;
            _studentService = studentService;
        }

        public async Task InsertAsync(DownloadFileDescription obj)
        {
            var pathEnd = obj.DownloadFile.Path + obj.DownloadFile.NameFile;
            var wb = new XLWorkbook(pathEnd);
            var planilha = wb.Worksheet(obj.PageNumber);

            var linha = 1;
            while (true)
            {
                if (string.IsNullOrEmpty(planilha.Cell("C" + linha.ToString()).Value.ToString())) break;
                string cpf = planilha.Cell("B" + linha.ToString()).Value.ToString();
                cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                var objec = await _mainBoardService.FindByCPFAsync(cpf);
                var obje2 = await _studentService.FindByEADAsync(planilha.Cell("A" + linha.ToString()).Value.ToString());
                if (objec == null && obje2 == null)
                {
                    string NameComplete = planilha.Cell("C" + linha.ToString()).Value.ToString();
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

                    MainBoard m1 = new MainBoard { Name = Name, LastName = LastName, CPF = cpf, RG = "00.000", Phone = "(XX)xxxx-xxxx", Cell = "(XX)x xxxx-xxxx", BirthDate = new DateTime(1990, 01, 01), Email = planilha.Cell("D" + linha.ToString()).Value.ToString(), Creation = new DateTime(2019, 08, 21) };
                    Student s1 = new Student { PeriodId = obj.PeriodId, MainBoard = m1, EAD = planilha.Cell("A" + linha.ToString()).Value.ToString(), NumberPeriod = 1, StudentRegistration = StudentRegistration.UnRegistered, Week = DayOfWeek.Friday };
                    Address a1 = new Address { MainBoard = m1, CEP = "Nulo", City = "Nulo", State = "Nulo", Neighborhood = "Nulo", Street = "Nulo", Number = "Nulo", Complement = "Nulo" };
                    await _context.MainBoard.AddAsync(m1);
                    await _context.Address.AddAsync(a1);
                    await _context.Student.AddAsync(s1);

                    linha++;
                }
                else if (objec != null && obje2 == null)
                {
                    Student s1 = new Student { PeriodId = obj.PeriodId, MainBoardId = objec.Id, EAD = planilha.Cell("A" + linha.ToString()).Value.ToString(), NumberPeriod = 1, StudentRegistration = StudentRegistration.UnRegistered, Week = DayOfWeek.Friday };
                    await _context.Student.AddAsync(s1);

                    linha++;
                }
                else
                {
                    linha++;
                }
            }
            _context.Entry(obj).Property("CommandExecuted").CurrentValue = CommandExecuted.Executed;
            //https://docs.microsoft.com/pt-br/ef/ef6/saving/change-tracking/property-values
            await _context.SaveChangesAsync();
            wb.Dispose();
        }

        public async Task InsertDataAsync(ImportDataFormViewModel obj, string pathFile, string nameFile, long sizeFile)
        {
            string[] pathFileEnd = pathFile.Split(nameFile);
            DownloadFile df1 = new DownloadFile { NameFile = nameFile, Path = pathFileEnd[0], PageNumbers = obj.DownloadFile.PageNumbers, TypeFile = obj.DownloadFile.TypeFile, Size = sizeFile, DateUpload = DateTime.Now };
            await _context.DownloadFile.AddAsync(df1);
            List<JsonImportData> jsonImport = JsonConvert.DeserializeObject<List<JsonImportData>>(obj.stringDownloadFileDescriptions);
            for (int i = 0; i < jsonImport.Count; i++)
            {
                DownloadFileDescription dfd1 = new DownloadFileDescription { DownloadFile = df1, NamePage = jsonImport[i].IdNamePage, PageNumber = Convert.ToInt32(jsonImport[i].IdPageNumber), PeriodId = Convert.ToInt32(jsonImport[i].IdPeriodList), Description = jsonImport[i].IdDescription, CommandExecuted = CommandExecuted.NotExecuted };
                await _context.DownloadFileDescription.AddRangeAsync(dfd1);
            }
            await _context.SaveChangesAsync();
        }
    }
}