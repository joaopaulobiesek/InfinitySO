using InfinitySO.Data;
using InfinitySO.Models.ModelsEmployee;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesEmployee
{
    public class JourneyService
    {
        private readonly ApplicationDbContext _context;

        public JourneyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Journey>> FindAllAsync()
        {
            return await _context.Journey.ToListAsync();
        }

        public async Task InsertAsync(Journey obj)
        {
            //Journey j = new Journey { Name = obj.Name, Duration = obj.Duration, Input1 = obj.Input1, Input2 = obj.Input2, Input3 = obj.Input3, Input4 = obj.Input4, Input5 = obj.Input5, Input6 = obj.Input6, Output1 = obj.Output1, Output2 = obj.Output2, Output3 = obj.Output3, Output4 = obj.Output4, Output5 = obj.Output5, Output6 = obj.Output6 };
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}