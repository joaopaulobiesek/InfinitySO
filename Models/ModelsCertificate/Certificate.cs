using InfinitySO.Models.ModelsAdministration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsCertificate
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public MainBoard MainBoard { get; set; }
        public CertificateCourse CertificateCourse { get; set; }

        [ForeignKey("MainBoard")]
        public int MainBoardId { get; set; }

        [ForeignKey("CertificateCourse")]
        public int CertificateCourseId { get; set; }
        public bool Pay { get; set; }
        public bool Approved { get; set; }
        
        public Certificate()
        {
        }

        public Certificate(int id, MainBoard mainBoard, CertificateCourse certificateCourse, bool pay, bool approved)
        {
            Id = id;
            MainBoard = mainBoard;
            CertificateCourse = certificateCourse;
            Pay = pay;
            Approved = approved;
        }
    }
}
