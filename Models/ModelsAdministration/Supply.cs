using InfinitySO.Models.Enums;
using System.Collections.Generic;
using System.Linq;

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
        public double MinimumOrderQuantity { get; set; }
        public int ActiveSupply { get; set; }
        public ICollection<SupplyAdd> AddSupplies { get; set; } = new List<SupplyAdd>();
        public ICollection<SupplyWithdrawal> SupplyWithdrawals { get; set; } = new List<SupplyWithdrawal>();

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
