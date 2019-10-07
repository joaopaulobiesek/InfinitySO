using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class PlaceService
    {
        private readonly ApplicationDbContext _context;

        public PlaceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Place>> FindAllAsync()
        {
            return await _context.Place.Include(x => x.Company).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Place obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}