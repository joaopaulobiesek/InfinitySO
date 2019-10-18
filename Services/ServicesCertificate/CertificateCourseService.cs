using InfinitySO.Data;
using InfinitySO.Models.JsonModels;
using InfinitySO.Models.ModelsCertificate;
using InfinitySO.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<CertificateCourse> FindByIdAsync(int id)
        {
            return await _context.CertificateCourse.Include(obj => obj.Company).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<CertificateCourse>> FindAllAsync()
        {
            return await _context.CertificateCourse.Include(x => x.Company).OrderBy(x => x.NameCourse).ToListAsync();
        }

        public async Task InsertAsync(CertificateFormViewModel obj)
        {
            string cpf = obj.CertificateCourse.NameCPF.Trim().Replace(".", "").Replace("-", "");
            cpf = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            CertificateCourse cc1 = new CertificateCourse
            {
                CompanyId = obj.CertificateCourse.CompanyId,
                NameCourse = obj.CertificateCourse.NameCourse.ToUpper(),
                NameSignature = obj.CertificateCourse.NameSignature,
                NameCPF = cpf,
                Hour = obj.CertificateCourse.Hour,
                Value = obj.CertificateCourse.Value,
                Amount = obj.CertificateCourse.Amount,
                InitialDate = obj.CertificateCourse.InitialDate,
                FinalDate = obj.CertificateCourse.FinalDate
            };
            _context.CertificateCourse.Add(cc1);
            List<JsonCertificateProgrammatic> jsonProgrammatics = JsonConvert.DeserializeObject<List<JsonCertificateProgrammatic>>(obj.stringContentProgrammatic);
            for (int i = 0; i < jsonProgrammatics.Count; i++)
            {
                CertificateProgrammatic cp1 = new CertificateProgrammatic { CertificateCourse = cc1, ProgrammaticContent = jsonProgrammatics[i].IdContentProgrammatics };
                _context.CertificateProgrammatic.AddRange(cp1);
            }
            await _context.SaveChangesAsync();
        }
    }
}
