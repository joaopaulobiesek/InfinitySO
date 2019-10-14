using InfinitySO.Models.ModelsEmployee;
using System;

namespace InfinitySO.Models.ModelsAdministration
{
    public class SupplyWithdrawal
    {
        public int Id { get; set; }
        public Supply Supply { get; set; }
        public Employee Employee { get; set; }
        public int SupplyId { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public double AmountWithdrawn { get; set; }
        public DateTime WithDrawalDate { get; set; }

        SupplyWithdrawal()
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