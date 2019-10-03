using InfinitySO.Data;
using InfinitySO.Models.ModelsEmployee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesEmployee
{
    public class ScaleService
    {
        private readonly ApplicationDbContext _context;

        public ScaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Scale>> FindAllAsync()
        {
            return await _context.Scale.ToListAsync();
        }

        public async Task InsertAsync(Scale obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}