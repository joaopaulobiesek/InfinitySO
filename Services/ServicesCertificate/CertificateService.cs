using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsCertificate;
using InfinitySO.Models.ViewModels;
using InfinitySO.Services.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesCertificate
{
    public class CertificateService
    {
        private readonly ApplicationDbContext _context;

        public CertificateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Certificate> FindByIdAsync(int id)
        {
            return await _context.Certificate.Include(x => x.CertificateCourse).Include(x => x.CertificateCourse.Company).Include(x => x.MainBoard).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<Certificate>> FindAllIdAsync(int id)
        {
            return await _context.Certificate.Include(x => x.CertificateCourse).Include(x => x.CertificateCourse.Company).Include(x => x.MainBoard).OrderBy(x => x.MainBoard.Name).ThenBy(x => x.MainBoard.LastName).Where(x => x.CertificateCourseId == id).ToListAsync();
        }

        public async Task InsertAsync(CertificateFormViewModel obj, MainBoard mainBoard)
        {
            _context.Add(obj.Certificate);
            _context.Entry(obj.Certificate).Property("MainBoardId").CurrentValue = mainBoard.Id;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CertificateFormViewModel obj)
        {
            bool hasAny = await _context.Certificate.AnyAsync(x => x.Id == obj.Certificate.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {                
                _context.Update(obj.Certificate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
