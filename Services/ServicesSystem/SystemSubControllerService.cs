using InfinitySO.Data;
using InfinitySO.Models.ModelsSystem;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesSystem
{
    public class SystemSubControllerService
    {
        private readonly ApplicationDbContext _context;

        public SystemSubControllerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SystemSubController>> FindAllAsync()
        {
            return await _context.SystemSubController.Include(obj => obj.SystemController).OrderBy(x => x.Name).ToListAsync();
        }
    }
}