using InfinitySO.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Supply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Unidade de Medida")]
        public MeasureType MeasureType { get; set; }
        [Display(Name = "Categoria")]
        public ProductCategory ProductCategory { get; set; }
        [Display(Name = "Nome do suprimento")]
        public string Name { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Valor da Medida")]
        public double ValueMeasure { get; set; }
        [Display(Name = "Quantidade minima para baixa de estoque")]
        public double MinimumOrderQuantity { get; set; }
        [Display(Name = "Ativa Produto")]
        public bool ActiveSupply { get; set; }
        public ICollection<SupplyAdd> AddSupplies { get; set; } = new List<SupplyAdd>();
        public ICollection<SupplyWithdrawal> SupplyWithdrawals { get; set; } = new List<SupplyWithdrawal>();
        [NotMapped]
        public ICollection<Supply> Supplies { get; set; } = new List<Supply>();

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

        public void AddSuppliesList(SupplyAdd sa)
        {
            AddSupplies.Add(sa);
        }

        public void RemoveSuppliesList(SupplyAdd sa)
        {
            AddSupplies.Remove(sa);
        }

        public void AddWithdrawalSuppliesList(SupplyWithdrawal ws)
        {
            SupplyWithdrawals.Add(ws);
        }

        public void RemoveWithdrawalSuppliesList(SupplyWithdrawal ws)
        {
            SupplyWithdrawals.Remove(ws);
        }

        public double TotalSuppliesAvailable(Supply supply)
        {
            var ItensAdd = AddSupplies.Where(sup => sup.SupplyId == supply.Id).Sum(sup => sup.QuantityAdded);
            var ItensRemove = SupplyWithdrawals.Where(sup => sup.SupplyId == supply.Id).Sum(sup => sup.AmountWithdrawn);
            return ItensAdd - ItensRemove;
        }
    }
}
