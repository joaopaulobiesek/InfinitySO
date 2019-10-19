using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsEmployee
{
    public class Scale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [NotMapped]
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        [NotMapped]
        public ICollection<Journey> Journeys { get; set; }

        public Scale()
        {
        }

        public Scale(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string TotalTime(DateTime initial, DateTime final)
        {
            TimeSpan tickspan = TimeSpan.Zero;
            List<DateTime> resultInt1 = new List<DateTime>();
            List<DateTime> resultOut1 = new List<DateTime>();
            List<DateTime> resultInt2 = new List<DateTime>();
            List<DateTime> resultOut2 = new List<DateTime>();
            List<DateTime> resultInt3 = new List<DateTime>();
            List<DateTime> resultOut3 = new List<DateTime>();
            List<DateTime> resultInt4 = new List<DateTime>();
            List<DateTime> resultOut4 = new List<DateTime>();
            List<DateTime> resultInt5 = new List<DateTime>();
            List<DateTime> resultOut5 = new List<DateTime>();
            List<DateTime> resultInt6 = new List<DateTime>();
            List<DateTime> resultOut6 = new List<DateTime>();
            foreach (var item in Employees.Select(Employees => Employees.SelectDateTime(initial, final)))
            {
                resultInt1.AddRange(item.Select(Employees => Employees.Input1));
                resultInt2.AddRange(item.Select(Employees => Employees.Input2));
                resultInt3.AddRange(item.Select(Employees => Employees.Input3));
                resultInt4.AddRange(item.Select(Employees => Employees.Input4));
                resultInt5.AddRange(item.Select(Employees => Employees.Input5));
                resultInt6.AddRange(item.Select(Employees => Employees.Input6));
                resultOut1.AddRange(item.Select(Employees => Employees.Output1));
                resultOut2.AddRange(item.Select(Employees => Employees.Output2));
                resultOut3.AddRange(item.Select(Employees => Employees.Output3));
                resultOut4.AddRange(item.Select(Employees => Employees.Output4));
                resultOut5.AddRange(item.Select(Employees => Employees.Output5));
                resultOut6.AddRange(item.Select(Employees => Employees.Output6));
            }
            for (int i = 0; i != resultInt1.Count; i++)
            {
                tickspan += new TimeSpan(resultOut1[i].Subtract(resultInt1[i]).Ticks);
                tickspan += new TimeSpan(resultOut2[i].Subtract(resultInt2[i]).Ticks);
                tickspan += new TimeSpan(resultOut3[i].Subtract(resultInt3[i]).Ticks);
                tickspan += new TimeSpan(resultOut4[i].Subtract(resultInt4[i]).Ticks);
                tickspan += new TimeSpan(resultOut5[i].Subtract(resultInt5[i]).Ticks);
                tickspan += new TimeSpan(resultOut6[i].Subtract(resultInt6[i]).Ticks);
            }
            string ResultDays = new TimeSpan(tickspan.Ticks).Days.ToString();
            string ResultHour = new TimeSpan(tickspan.Ticks).Hours.ToString();
            string ResultMinu = new TimeSpan(tickspan.Ticks).Minutes.ToString();
            string ResultSeco = new TimeSpan(tickspan.Ticks).Seconds.ToString();
            string dif = ResultDays + "Day(s) " + ResultHour + ":" + ResultMinu + ":" + ResultSeco;

            return dif;
        }
    }
}