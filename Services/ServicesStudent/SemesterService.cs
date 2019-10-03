using InfinitySO.Data;
using InfinitySO.Models.ModelsStudent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesStudent
{
    public class SemesterService
    {
        private readonly ApplicationDbContext _context;

        public SemesterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Semester>> FindAllAsync()
        {
            return await _context.Semester.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Semester obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}