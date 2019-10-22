using InfinitySO.Models.ModelsEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class SupplyWithdrawal
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
        public string Description { get; set; }
        public double AmountWithdrawn { get; set; }
        public DateTime WithDrawalDate { get; set; }

        [NotMapped]
        public ICollection<SupplyWithdrawal> SupplyWithdrawals { get; set; } = new List<SupplyWithdrawal>();

        public SupplyWithdrawal()
        {
        }

        public SupplyWithdrawal(int id, Supply supply, Employee employee, string description, double amountWithdrawn, DateTime withDrawalDate)
        {
            Id = id;
            Supply = supply;
            Employee = employee;
            Description = description;
            AmountWithdrawn = amountWithdrawn;
            WithDrawalDate = withDrawalDate;
        }
    }
}