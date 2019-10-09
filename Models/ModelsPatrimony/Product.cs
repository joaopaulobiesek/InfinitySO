using InfinitySO.Models.Enums;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, ProductCategory productCategory)
        {
            Id = id;
            Name = name;
            ProductCategory = productCategory;
        }
    }
}