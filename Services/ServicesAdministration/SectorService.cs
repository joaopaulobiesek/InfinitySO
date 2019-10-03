using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class SectorService
    {
        private readonly ApplicationDbContext _context;

        public SectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sector>> FindAllAsync()
        {
            return await _context.Sector.Include(obj => obj.Department).ToListAsync();
        }

        public async Task InsertAsync(Sector obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}