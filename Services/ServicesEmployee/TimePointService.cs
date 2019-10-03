using InfinitySO.Data;
using InfinitySO.Models.ModelsEmployee;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesEmployee
{
    public class TimePointService
    {
        private readonly ApplicationDbContext _context;

        public TimePointService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(TimePoint obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}