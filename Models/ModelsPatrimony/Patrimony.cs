using InfinitySO.Models.ModelsAdministration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class Patrimony
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Referência do lugar")]
        public int CategoryId { get; set; }

        [ForeignKey("SubCategory")]
        [Display(Name = "Nome do patrimônio")]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Quantidade do patrimônio")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Quantidade de baixas do patrimônio")]
        public int LowQuantity { get; set; }

        [NotMapped]
        public ICollection<Category> Categories { get; set; }
        [NotMapped]
        public ICollection<SubCategory> SubCategories { get; set; }

        public Patrimony()
        {
        }

        public Patrimony(int id, Category category, SubCategory subCategory, int quantity, int lowQuantity)
        {
            Id = id;
            Category = category;
            SubCategory = subCategory;
            Quantity = quantity;
            LowQuantity = lowQuantity;
        }
    }
}