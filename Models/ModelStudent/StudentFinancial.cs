using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.Enums;

namespace InfinitySO.Models.ModelsStudent
{
    public class StudentFinancial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Display(Name = "Valor em Aberto")]
        public double OpenValue { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data da negociação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime DateNegotiation { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data do vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd}")]
        [Column(TypeName = "date")]
        public DateTime DateDueBillet { get; set; }
        [Display(Name = "Estado da negociação")]
        public StudentFinancialNegotiation StudentFinancialNegotiation { get; set; }
        [Display(Name = "Parcelas")]
        public StudentFinanceInstallment StudentFinanceInstallment { get; set; }

        public StudentFinancial()
        {
        }

        public StudentFinancial(int id, Student student, double openValue, DateTime dateNegotiation, DateTime dateDueBillet, StudentFinancialNegotiation studentFinancialNegotiation, StudentFinanceInstallment studentFinanceInstallment)
        {
            Id = id;
            Student = student;
            OpenValue = openValue;
            DateNegotiation = dateNegotiation;
            DateDueBillet = dateDueBillet;
            StudentFinancialNegotiation = studentFinancialNegotiation;
            StudentFinanceInstallment = studentFinanceInstallment;
        }
    }
}