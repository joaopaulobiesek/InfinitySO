using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.Include(x => x.Place).Include(x => x.Place.Company).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Category obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}