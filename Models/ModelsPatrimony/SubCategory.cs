using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Nome do patrimônio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Descrição do patrimônio")]
        public string Description { get; set; }

        public SubCategory()
        {
        }

        public SubCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}