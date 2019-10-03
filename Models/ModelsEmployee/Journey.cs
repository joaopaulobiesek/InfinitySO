using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsEmployee
{
    public class Journey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(5)]
        public string Duration { get; set; }
        [StringLength(5)]
        public String Input1 { get; set; }
        [StringLength(5)]
        public String Input2 { get; set; }
        [StringLength(5)]
        public String Input3 { get; set; }
        [StringLength(5)]
        public String Input4 { get; set; }
        [StringLength(5)]
        public String Input5 { get; set; }
        [StringLength(5)]
        public String Input6 { get; set; }
        [StringLength(5)]
        public string Output1 { get; set; }
        [StringLength(5)]
        public string Output2 { get; set; }
        [StringLength(5)]
        public string Output3 { get; set; }
        [StringLength(5)]
        public string Output4 { get; set; }
        [StringLength(5)]
        public string Output5 { get; set; }
        [StringLength(5)]
        public string Output6 { get; set; }

        public Journey()
        {
        }

        public Journey(int id, string name, string duration, string input1, string input2, string input3, string input4, string input5, string input6, string output1, string output2, string output3, string output4, string output5, string output6)
        {
            Id = id;
            Name = name;
            Duration = duration;
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
        }
    }
}