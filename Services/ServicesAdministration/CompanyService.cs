using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Company> FindByCNPJAsync(string cnpj)
        {
            return await _context.Company.FirstOrDefaultAsync(obj => obj.CNPJ == cnpj);
        }

        public async Task<List<Company>> FindAllAsync()
        {
            return await _context.Company.OrderBy(x => x.CorporateName).ToListAsync();
        }

        public async Task InsertCreateAsync(Company obj)
        {
            string cnpj = obj.CNPJ;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            cnpj = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            _context.Add(obj);
            _context.Entry(obj).Property("CNPJ").CurrentValue = cnpj;
            await _context.SaveChangesAsync();
        }
        public async Task InsertAsync(CompanyFormViewModel obj)
        {
            string cnpj = obj.Company.CNPJ;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            cnpj = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
            Company c1 = new Company { CorporateName = obj.Company.CorporateName, FantasyName = obj.Company.FantasyName, CNPJ = cnpj, StateRegistration = obj.Company.StateRegistration, Phone = obj.Company.Phone, Cell= obj.Company.Cell, Email = obj.Company.Email, Creation = obj.Company.Creation };
            Address a1 = new Address {Company = c1, CEP = obj.Address.CEP, City = obj.Address.City, State = obj.Address.State, Neighborhood = obj.Address.Neighborhood, Street = obj.Address.Street, Number = obj.Address.Number, Complement = obj.Address.Complement };
            _context.Company.Add(c1);
            _context.Address.Add(a1);
            await _context.SaveChangesAsync();
        }
    }
}