using InfinitySO.Data;
using InfinitySO.Models.ModelsPatrimony;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesPatrimony
{
    public class HistoricPatrimonyService
    {
        private readonly ApplicationDbContext _context;

        public HistoricPatrimonyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistoricPatrimony>> FindAllAsync()
        {
            return await _context.HistoricPatrimony.Include(x => x.Patrimony).Include(x => x.Patrimony.Place).OrderBy(x => x.Patrimony.KeyPatrimony).ToListAsync();
        }

        public async Task InsertAsync(HistoricPatrimony obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
