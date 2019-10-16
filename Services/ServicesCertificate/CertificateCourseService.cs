using InfinitySO.Data;
using InfinitySO.Models.ModelsCertificate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesCertificate
{
    public class CertificateCourseService
    {
        private readonly ApplicationDbContext _context;

        public CertificateCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CertificateCourse>> FindAllAsync()
        {
            return await _context.CertificateCourse.Include(x => x.Company).OrderBy(x => x.NameCourse).ToListAsync();
        }

        public async Task<CertificateCourse> FindByIdAsync(int id)
        {
            return await _context.CertificateCourse.Include(obj => obj.Company).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(CertificateCourse obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
