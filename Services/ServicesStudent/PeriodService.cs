using InfinitySO.Data;
using InfinitySO.Models.ModelsStudent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesStudent
{
    public class PeriodService
    {
        private readonly ApplicationDbContext _context;

        public PeriodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Period>> FindAllAsync()
        {
            return await _context.Period.Include(obj => obj.Course).Include(obj => obj.Semester).OrderBy(x => x.Course.Name).ToListAsync();
        }

        public async Task InsertAsync(Period obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}