using InfinitySO.Data;
using InfinitySO.Models.ModelsStudent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesStudent
{
    public class BilletValueService
    {
        private readonly ApplicationDbContext _context;

        public BilletValueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(BilletValue obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BilletValue>> FindByIdListAsync(int id)
        {
            return await _context.BilletValue.Where(obj => obj.StudentFinancialId == id).ToListAsync();
        }

        public async Task<BilletValue> FindByIdAsync(int id)
        {
            return await _context.BilletValue.Include(obj => obj.StudentFinancial.Student).Include(obj => obj.StudentFinancial.Student.MainBoard).Include(obj => obj.StudentFinancial).FirstOrDefaultAsync(obj => obj.StudentFinancialId == id);
        }

        public async Task<List<BilletValue>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.BilletValue select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DateDue >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DateDue <= maxDate.Value);
            }
            return await result
                .Include(x => x.StudentFinancial)
                .Include(x => x.StudentFinancial.Student)
                .Include(x => x.StudentFinancial.Student.MainBoard)
                .OrderByDescending(x => x.DateDue)
                .ToListAsync();
        }
    }
}