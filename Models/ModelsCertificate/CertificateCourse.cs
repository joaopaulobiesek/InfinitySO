using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Services.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsCertificate
{
    public class CertificateCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Display(Name = "Curso")]
        public string NameCourse { get; set; }

        [Display(Name = "Nome do Instrutor")]
        public string NameSignature { get; set; }

        [Required]
        [StringLength(20)]
        [CPFValidation]
        [Display(Name = "CPF do Instrutor")]
        public string NameCPF { get; set; }

        [Display(Name = "Carga Horaria")]
        [StringLength(4)]
        public string Hour { get; set; }

        [Display(Name = "Valor do curso")]
        public double Value { get; set; }

        [Display(Name = "Vagas")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime InitialDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime FinalDate { get; set; }

        [NotMapped]
        public ICollection<CertificateCourse> CertificateCourses { get; set; }
        [NotMapped]
        public ICollection<Company> Companies { get; set; }

        public CertificateCourse()
        {
        }

        public CertificateCourse(int id, Company company, string nameCourse, string nameSignature, string nameCPF, string hour, double value, int amount, DateTime initialDate, DateTime finalDate)
        {
            Id = id;
            Company = company;
            NameCourse = nameCourse;
            NameSignature = nameSignature;
            NameCPF = nameCPF;
            Hour = hour;
            Value = value;
            Amount = amount;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }
    }
}