﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsCertificate
{
    public class CertificateProgrammatic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public CertificateCourse CertificateCourse { get; set; }

        [ForeignKey("CertificateCourse")]
        public int CertificateCourseId { get; set; }
        public int Cod { get; set; }
        public string ProgrammaticContent { get; set; }

        public CertificateProgrammatic()
        {
        }

        public CertificateProgrammatic(int id, CertificateCourse certificateCourse, int cod, string programmaticContent)
        {
            Id = id;
            CertificateCourse = certificateCourse;
            Cod = cod;
            ProgrammaticContent = programmaticContent;
        }
    }
}
