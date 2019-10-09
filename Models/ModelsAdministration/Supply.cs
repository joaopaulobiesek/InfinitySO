using InfinitySO.Models.Enums;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Supply
    {
        public int Id { get; set; }
        public MeasureType MeasureType { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ValueMeasure { get; set; }

        public Supply()
        {
        }

        public Supply(int id, MeasureType measureType, ProductCategory productCategory, string name, string description, double valueMeasure)
        {
            Id = id;
            MeasureType = measureType;
            ProductCategory = productCategory;
            Name = name;
            Description = description;
            ValueMeasure = valueMeasure;
        }
    }
}
