using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsEmployee
{
    public class TimePoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public DateTime Input1 { get; set; }
        public DateTime Input2 { get; set; }
        public DateTime Input3 { get; set; }
        public DateTime Input4 { get; set; }
        public DateTime Input5 { get; set; }
        public DateTime Input6 { get; set; }
        public DateTime Output1 { get; set; }
        public DateTime Output2 { get; set; }
        public DateTime Output3 { get; set; }
        public DateTime Output4 { get; set; }
        public DateTime Output5 { get; set; }
        public DateTime Output6 { get; set; }
        public DateTime DateDay { get; set; }
        [Column(TypeName = "text")]
        public string Observation { get; set; }

        [NotMapped]
        public ICollection<Employee> Employees { get; set; }

        public TimePoint()
        {
        }

        public TimePoint(int id, Employee employee, DateTime input1, DateTime input2, DateTime input3, DateTime input4, DateTime input5, DateTime input6, DateTime output1, DateTime output2, DateTime output3, DateTime output4, DateTime output5, DateTime output6, DateTime dateDay, string observation)
        {
            Id = id;
            Employee = employee;
            Input1 = input1;
            Input2 = input2;
            Input3 = input3;
            Input4 = input4;
            Input5 = input5;
            Input6 = input6;
            Output1 = output1;
            Output2 = output2;
            Output3 = output3;
            Output4 = output4;
            Output5 = output5;
            Output6 = output6;
            DateDay = dateDay;
            Observation = observation;
        }
    }
}