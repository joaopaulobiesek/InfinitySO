using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsCertificate;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class CertificateFormViewModel
    {
        public Certificate Certificate { get; set; }
        public CertificateCourse CertificateCourse { get; set; }
        public CertificateProgrammatic CertificateProgrammatic { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<CertificateProgrammatic> CertificateProgrammatics { get; set; }
        public ICollection<CertificateCourse> CertificateCourses { get; set; }
        public ICollection<Company> Companies { get; set; }
        public string stringContentProgrammatic { get; set; }
    }
}
