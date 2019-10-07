using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Company Company { get; set; }
        [ForeignKey("Company")]
        [Display(Name = "Nome da Empresa")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Nome do Lugar")]
        public string Name { get; set; }

        [NotMapped]
        public ICollection<Company> Companies { get; set; }
        [NotMapped]
        public ICollection<Place> Places { get; set; }

        public Place()
        {
        }

        public Place(int id, Company company, string name)
        {
            Id = id;
            Company = company;
            Name = name;
        }
    }
}