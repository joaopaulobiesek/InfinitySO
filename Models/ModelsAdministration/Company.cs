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
        public string CorporateName { get; set; }
        [Required]
        [StringLength(60)]
        public string FantasyName { get; set; }
        [Required]
        [StringLength(20)]
        public string CNPJ { get; set; }
        [Required]
        [StringLength(20)]
        public string StateRegistration { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(15)]
        public string Cell { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Date Create Company")]
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