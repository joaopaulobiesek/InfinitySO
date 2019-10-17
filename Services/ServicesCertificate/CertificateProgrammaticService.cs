using InfinitySO.Data;
using InfinitySO.Models.ModelsCertificate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesCertificate
{
    public class CertificateProgrammaticService
    {
        private readonly ApplicationDbContext _context;

        public CertificateProgrammaticService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CertificateProgrammatic>> FindAllIdAsync(int id)
        {
            return await _context.CertificateProgrammatic.Include(x => x.CertificateCourse).OrderBy(x => x.ProgrammaticContent).Where(x => x.CertificateCourseId == id).ToListAsync();
        }
    }
}
