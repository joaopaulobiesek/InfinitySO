using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.ModelsEmployee;
using InfinitySO.Models.ModelsUserDataLogin;
using InfinitySO.Services.Validation;

namespace InfinitySO.Models.ModelsAdministration
{
    public class MainBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [CPFValidation]
        public string CPF { get; set; }
        [Required]
        [StringLength(20)]
        public string RG { get; set; }
        [StringLength(15)]
        public String Phone { get; set; }
        [Required]
        [StringLength(15)]
        public string Cell { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime Creation { get; set; }
        [NotMapped]
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        [NotMapped]
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        [NotMapped]
        public ICollection<UserDataLogin> UseresDataLogin { get; set; } = new List<UserDataLogin>();


        public MainBoard()
        {
        }

        public MainBoard(int id, string name, string lastName, string cPF, string rG, string phone, string cell, DateTime birthDate, string email, DateTime creation)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            CPF = cPF;
            RG = rG;
            Phone = phone;
            Cell = cell;
            BirthDate = birthDate;
            Email = email;
            Creation = creation;
        }
    }
}