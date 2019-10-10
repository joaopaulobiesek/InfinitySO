using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Patrimony> FindByKeyAsync(string key)
        {
            return await _context.Patrimony.FirstOrDefaultAsync(obj => obj.KeyPatrimony == key);
        }

        public async Task<List<Patrimony>> FindAllAsync()
        {
            return await _context.Patrimony.Include(x => x.Place.Company).Include(x => x.Place).Include(x => x.Product).OrderBy(x => x.KeyPatrimony).ToListAsync();
        }

        public async Task InsertAsync(Patrimony obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
