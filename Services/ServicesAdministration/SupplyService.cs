using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class SupplyService
    {
        private readonly ApplicationDbContext _context;

        public SupplyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Supply obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Supply> FindByNameAsync(string name)
        {
            return await _context.Supply.FirstOrDefaultAsync(obj => obj.Name.ToUpper() == name.ToUpper());
        }

        public async Task<List<Supply>> FindAllAsync()
        {
            return await _context.Supply.OrderBy(x => x.Name).ThenBy(x => x.ActiveSupply).ToListAsync();
        }
    }
}
