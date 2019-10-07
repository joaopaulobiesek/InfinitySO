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

        public async Task<Patrimony> FindByCatSubAsync(int categoryId, int subCategoryId)
        {
            return await _context.Patrimony.FirstOrDefaultAsync(obj => obj.CategoryId == categoryId && obj.SubCategoryId == subCategoryId);
        }

        public async Task<List<Patrimony>> FindAllAsync()
        {
            return await _context.Patrimony.Include(obj => obj.Category).Include(obj => obj.Category.Place).Include(obj => obj.Category.Place.Company).Include(obj => obj.SubCategory).ToListAsync();
        }

        public async Task InsertAsync(Patrimony obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}