using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Sector.Include(obj => obj.Department).OrderBy(x => x.Department.Name).ThenBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Sector obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}