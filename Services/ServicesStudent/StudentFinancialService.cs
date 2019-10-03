using InfinitySO.Data;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.Enums;
using InfinitySO.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using InfinitySO.Services.Exception;

namespace InfinitySO.Services.ServicesStudent
{
    public class StudentFinancialService
    {
        private readonly ApplicationDbContext _context;

        public StudentFinancialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentFinancial>> FindAllAsync()
        {
            return await _context.StudentFinancial.Include(obj => obj.Student).Include(obj => obj.Student.MainBoard).OrderByDescending(x => x.DateDueBillet).ToListAsync();
        }

        public async Task InsertCreateAsync(StudentFinancial obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(StudentFinancialFormViewModel obj)
        {
            StudentFinancial sf1 = new StudentFinancial { StudentId = obj.StudentFinancial.StudentId, OpenValue = obj.StudentFinancial.OpenValue, DateNegotiation = obj.StudentFinancial.DateNegotiation, DateDueBillet = obj.StudentFinancial.DateDueBillet, StudentFinancialNegotiation = obj.StudentFinancial.StudentFinancialNegotiation, StudentFinanceInstallment = obj.StudentFinancial.StudentFinanceInstallment };
            _context.StudentFinancial.Add(sf1);
            List<JsonBilletsValue> jsonBillets = JsonConvert.DeserializeObject<List<JsonBilletsValue>>(obj.stringBilletValues);
            for (int i = 0; i < jsonBillets.Count; i++)
            {
                BilletValue bv1 = new BilletValue { StudentFinancial = sf1, DateDue = Convert.ToDateTime(jsonBillets[i].IdDateDue), ValueBillet = double.Parse(jsonBillets[i].IdValueBillet.Replace(",", "."), CultureInfo.InvariantCulture), BilletPay = (BilletPay)Enum.Parse(typeof(BilletPay), jsonBillets[i].IdBilletPay) };
                _context.BilletValue.AddRange(bv1);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentFinancialFormViewModel obj)
        {
            bool hasAny = await _context.StudentFinancial.AnyAsync(x => x.Id == obj.StudentFinancial.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                foreach (var item in obj.BilletValues)
                {
                    BilletValue bv1 = new BilletValue
                    {
                        Id = item.Id,
                        StudentFinancialId = item.StudentFinancialId,
                        DateDue = item.DateDue,
                        ValueBillet = item.ValueBillet,
                        BilletPay = item.BilletPay
                    };
                    _context.Update(bv1);
                }
                StudentFinancial sf1 = new StudentFinancial
                {
                    Id = obj.StudentFinancial.Id,
                    StudentId = obj.StudentFinancial.StudentId,
                    OpenValue = obj.StudentFinancial.OpenValue,
                    DateNegotiation = obj.StudentFinancial.DateNegotiation,
                    DateDueBillet = obj.StudentFinancial.DateDueBillet,
                    StudentFinancialNegotiation = obj.StudentFinancial.StudentFinancialNegotiation,
                    StudentFinanceInstallment = obj.StudentFinancial.StudentFinanceInstallment
                };
                _context.Update(sf1);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}