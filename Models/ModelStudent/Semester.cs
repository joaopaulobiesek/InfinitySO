using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsStudent
{
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Semestre")]
        public string Name { get; set; }

        public Semester()
        {
        }

        public Semester(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}