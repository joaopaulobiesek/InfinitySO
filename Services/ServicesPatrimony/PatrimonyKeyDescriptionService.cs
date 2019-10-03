using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesPatrimony
{
    public class PatrimonyKeyDescriptionService
    {
        private readonly ApplicationDbContext _context;

        public PatrimonyKeyDescriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PatrimonyKeyDescription>> FindAllAsync()
        {
            return await _context.PatrimonyKeyDescription.Include(obj => obj.PatrimonyKey).ToListAsync();
        }

        public async Task InsertAsync(PatrimonyKeyDescription obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}