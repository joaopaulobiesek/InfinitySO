using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesPatrimony
{
    public class SubCategoryService
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategory>> FindAllAsync()
        {
            return await _context.SubCategory.ToListAsync();
        }

        public async Task InsertAsync(SubCategory obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}