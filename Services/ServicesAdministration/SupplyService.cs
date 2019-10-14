using InfinitySO.Data;
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
    }
}
