using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsStudent
{
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Número")]
        public int Number { get; set; }
        [Display(Name = "Semestre")]
        public string Name { get; set; }

        public Semester()
        {
        }

        public Semester(int id, int number, string name)
        {
            Id = id;
            Number = number;
            Name = name;
        }
    }
}