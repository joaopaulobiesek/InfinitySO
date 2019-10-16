using InfinitySO.Data;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsCertificate;
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

        public async Task<List<Certificate>> FindAllIdAsync(int id)
        {
            return await _context.Certificate.Include(x => x.CertificateCourse).Include(x => x.CertificateCourse.Company).Include(x => x.MainBoard).OrderBy(x => x.MainBoard.Name).ThenBy(x => x.MainBoard.LastName).Where(x => x.CertificateCourseId == id).ToListAsync();
        }

        public async Task InsertAsync(Certificate obj, MainBoard mainBoard)
        {
            _context.Add(obj);
            _context.Entry(obj).Property("MainBoardId").CurrentValue = mainBoard.Id;
            await _context.SaveChangesAsync();
        }
    }
}
