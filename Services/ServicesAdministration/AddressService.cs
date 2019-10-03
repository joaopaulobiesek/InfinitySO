using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class AddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Address obj)
        {
            // Address address = new Address { MainBoard = obj.MainBoard, CEP = obj.CEP, City = obj.City, State = obj.State, Neighborhood = obj.Neighborhood, Street = obj.Street, Number = obj.Number, Complement = obj.Complement };
            _context.Add(obj);
            await _context.SaveChangesAsync();
            //return 
        }
    }
}