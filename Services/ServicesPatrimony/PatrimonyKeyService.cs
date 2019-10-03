using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesPatrimony
{
    public class PatrimonyKeyService
    {
        private readonly ApplicationDbContext _context;

        public PatrimonyKeyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatrimonyKey>> FindAllAsync()
        {
            return await _context.PatrimonyKey.Include(obj => obj.Patrimony).Include(obj => obj.Sector).ToListAsync();
        }

        public async Task InsertAsync(PatrimonyKey obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}