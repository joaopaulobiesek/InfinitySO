using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using InfinitySO.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InfinitySO.Models.ModelsStudent
{
    public class BilletValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public StudentFinancial StudentFinancial { get; set; }
        [ForeignKey("StudentFinancial")]
        public int StudentFinancialId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data do vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime DateDue { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Valor do boleto")]
        public double ValueBillet { get; set; }
        [Display(Name = "Status do pagamento")]
        public BilletPay BilletPay { get; set; }

        public BilletValue()
        {
        }

        public BilletValue(int id, StudentFinancial studentFinancial, DateTime dateDue, double valueBillet, BilletPay billetPay)
        {
            Id = id;
            StudentFinancial = studentFinancial;
            DateDue = dateDue;
            ValueBillet = valueBillet;
            BilletPay = billetPay;
        }
    }
}