using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public MainBoard MainBoard { get; set; }
        public Company Company { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }
        [Required]
        [StringLength(12)]
        public string CEP { get; set; }
        [Required]
        [StringLength(60)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string Neighborhood { get; set; }
        [Required]
        [StringLength(60)]
        public string Street { get; set; }
        [Required]
        [StringLength(5)]
        public string Number { get; set; }
        [StringLength(60)]
        public string Complement { get; set; }

        [NotMapped]
        public ICollection<MainBoard> MainBoards { get; set; }
        [NotMapped]
        public ICollection<Company> Companies { get; set; }

        public Address()
        {
        }

        public Address(int id, MainBoard mainBoard, Company company, string state, string cEP, string city, string neighborhood, string street, string number, string complement)
        {
            Id = id;
            MainBoard = mainBoard;
            Company = company;
            State = state;
            CEP = cEP;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            Complement = complement;
        }
    }
}