using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Place Place { get; set; }
        [ForeignKey("Place")]
        [Display(Name = "Nome do lugar")]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Capacidade do lugar")]
        public int AmountPeople { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Referência do lugar")]
        public string Name { get; set; }

        [NotMapped]
        public ICollection<Place> Places { get; set; }

        public Category()
        {
        }

        public Category(int id, Place place, int amountPeople, string name)
        {
            Id = id;
            Place = place;
            AmountPeople = amountPeople;
            Name = name;
        }
    }
}