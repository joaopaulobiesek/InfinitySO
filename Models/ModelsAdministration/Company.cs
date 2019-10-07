using InfinitySO.Services.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Razão Social")]
        public string CorporateName { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Nome Fantasia")]
        public string FantasyName { get; set; }
        [Required]
        [StringLength(20)]
        [CNPJValidation]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Inscrição Estadual")]
        public string StateRegistration { get; set; }
        [StringLength(15)]
        [Display(Name = "Telefone Fixo")]
        public string Phone { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Celular")]
        public string Cell { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(250)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data de Abertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime Creation { get; set; }

        public Company()
        {
        }

        public Company(int id, string corporateName, string fantasyName, string cNPJ, string stateRegistration, string phone, string cell, string email, DateTime creation)
        {
            Id = id;
            CorporateName = corporateName;
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            StateRegistration = stateRegistration;
            Phone = phone;
            Cell = cell;
            Email = email;
            Creation = creation;
        }
    }
}