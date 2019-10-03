using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesAdministration
{
    public class MainBoardService
    {
        private readonly ApplicationDbContext _context;

        public MainBoardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MainBoard> FindByCPFAsync(string cpf)
        {
            return await _context.MainBoard.FirstOrDefaultAsync(obj => obj.CPF == cpf);
        }

        public async Task<MainBoard> FindByEmailAsync(string email)
        {
            return await _context.MainBoard.FirstOrDefaultAsync(obj => obj.Email == email);
        }

        public async Task<List<MainBoard>> FindAllAsync()
        {
            return await _context.MainBoard.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToListAsync();
        }

        public async Task<MainBoard> FindByIdAsync(int id)
        {
            return await _context.MainBoard.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(MainBoard obj)
        {
            string cpf = obj.CPF;
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            _context.Add(obj);
            _context.Entry(obj).Property("CPF").CurrentValue = cpf;
            await _context.SaveChangesAsync();
        }
    }
}