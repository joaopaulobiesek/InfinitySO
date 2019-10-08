using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PatrimonyKey> FindByKeyAsync(string key)
        {
            return await _context.PatrimonyKey.FirstOrDefaultAsync(obj => obj.KeyPatrimony == key);
        }

        public async Task<List<PatrimonyKey>> FindAllAsync()
        {
            return await _context.PatrimonyKey.Include(obj => obj.Patrimony).Include(obj => obj.Patrimony.SubCategory)
                                              .Include(obj => obj.Patrimony.Category).Include(obj => obj.Patrimony.Category.Place)
                                              .Include(obj => obj.Patrimony.Category.Place.Company)
                                              .Include(obj => obj.Sector).Include(obj => obj.Sector.Department).ToListAsync();
        }

        public async Task InsertAsync(PatrimonyKey obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}