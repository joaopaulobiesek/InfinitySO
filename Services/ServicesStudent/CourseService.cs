using InfinitySO.Data;
using InfinitySO.Models.ModelsStudent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesStudent
{
    public class CourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> FindAllAsync()
        {
            return await _context.Course.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Course obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}