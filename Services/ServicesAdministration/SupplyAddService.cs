using InfinitySO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class SupplyAddService
    {
        private readonly ApplicationDbContext _context;

        public SupplyAddService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
