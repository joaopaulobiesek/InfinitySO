using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesStudent
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> FindByEADAsync(string ead)
        {
            return await _context.Student.FirstOrDefaultAsync(obj => obj.EAD == ead);
        }

        public async Task<List<Student>> FindAllAsync()
        {
            return await _context.Student.Include(obj => obj.MainBoard).OrderBy(x => x.MainBoard.Name).ThenBy(x => x.MainBoard.LastName).ToListAsync();
        }

        public async Task InsertAsync(Student obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task InsertCompleteAsync(StudentFormViewModel obj)
        {
            string cpf = obj.MainBoard.CPF.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            MainBoard m1 = new MainBoard { Name = obj.MainBoard.Name.ToUpper(), LastName = obj.MainBoard.LastName.ToUpper(), CPF = cpf, RG = obj.MainBoard.RG, Phone = obj.MainBoard.Phone, Cell = obj.MainBoard.Cell, BirthDate = obj.MainBoard.BirthDate, Email = obj.MainBoard.Email, Creation = DateTime.Now };
            Address a1 = new Address { MainBoard = m1, CEP = obj.Address.CEP, City = obj.Address.City, State = obj.Address.State, Neighborhood = obj.Address.Neighborhood, Street = obj.Address.Street, Number = obj.Address.Number, Complement = obj.Address.Complement };
            Student s1 = new Student { MainBoard = m1, EAD = obj.Student.EAD, Week = obj.Student.Week, NumberPeriod = obj.Student.NumberPeriod, StudentRegistration = obj.Student.StudentRegistration, PeriodId = obj.Student.PeriodId };
            _context.MainBoard.Add(m1);
            _context.Address.Add(a1);
            _context.Student.Add(s1);
            await _context.SaveChangesAsync();
        }

        public async Task InsertEADAsync(StudentFormViewModel obj)
        {
            Student s1 = new Student { MainBoardId = obj.MainBoard.Id, EAD = obj.Student.EAD, Week = obj.Student.Week, NumberPeriod = obj.Student.NumberPeriod, StudentRegistration = obj.Student.StudentRegistration, PeriodId = obj.Student.PeriodId };
            _context.Student.Add(s1);
            await _context.SaveChangesAsync();
        }
    }
}