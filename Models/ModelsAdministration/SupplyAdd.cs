using InfinitySO.Models.ModelsEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InfinitySO.Models.ModelsAdministration
{
    public class SupplyAdd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Supply Supply { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Supply")]
        public int SupplyId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public double QuantityAdded { get; set; }
        public string Description { get; set; }
        [Display(Name = "Numero da Nota Fiscal")]
        public string InvoiceNumber { get; set; }
        public DateTime AddDate { get; set; }

        [NotMapped]
        public ICollection<SupplyAdd> SupplyAdds { get; set; } = new List<SupplyAdd>();

        public SupplyAdd()
        {
        }

        public SupplyAdd(int id, Supply supply, Employee employee, double quantityAdded, string description, string invoiceNumber, DateTime addDate)
        {
            Id = id;
            Supply = supply;
            Employee = employee;
            QuantityAdded = quantityAdded;
            Description = description;
            InvoiceNumber = invoiceNumber;
            AddDate = addDate;
        }
    }
}
