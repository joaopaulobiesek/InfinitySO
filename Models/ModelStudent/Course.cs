using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsStudent
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Curso")]
        public string Name { get; set; }

        public Course()
        {
        }

        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}