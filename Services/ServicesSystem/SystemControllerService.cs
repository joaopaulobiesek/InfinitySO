using InfinitySO.Data;
using InfinitySO.Models.ModelsSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesSystem
{
    public class SystemControllerService
    {
        private readonly ApplicationDbContext _context;

        public SystemControllerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SystemController>> FindAllAsync()
        {
            return await _context.SystemController.OrderBy(x => x.Name).ToListAsync();
        }
    }
}