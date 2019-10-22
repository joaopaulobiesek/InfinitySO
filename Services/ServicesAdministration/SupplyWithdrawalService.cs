using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class SupplyWithdrawalService
    {
        private readonly ApplicationDbContext _context;

        public SupplyWithdrawalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplyWithdrawal>> FindAllIdAsync(int id)
        {
            return await _context.SupplyWithdrawal.Include(x => x.Employee).Include(x => x.Employee.MainBoard).Include(x => x.Supply).Where(x => x.SupplyId == id).ToListAsync();
        }
    }
}
