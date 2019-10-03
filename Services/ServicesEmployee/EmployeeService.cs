using InfinitySO.Data;
using InfinitySO.Models.ModelsEmployee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesEmployee
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> FindAllAsync()
        {
            return await _context.Employee.Include(obj => obj.MainBoard).ToListAsync();
        }

        public async Task InsertAsync(Employee obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}