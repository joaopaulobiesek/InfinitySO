using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesPatrimony
{
    public class PatrimonyService
    {
        private readonly ApplicationDbContext _context;

        public PatrimonyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patrimony>> FindAllAsync()
        {
            return await _context.Patrimony.Include(obj => obj.Category).Include(obj => obj.SubCategory).ToListAsync();
        }

        public async Task InsertAsync(Patrimony obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}