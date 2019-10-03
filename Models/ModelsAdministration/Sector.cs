using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Sector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        public string Initials { get; set; }

        [NotMapped]
        public ICollection<Department> Departments { get; set; }

        public Sector()
        {
        }

        public Sector(int id, Department department, string name, string initials)
        {
            Id = id;
            Department = department;
            Name = name;
            Initials = initials;
        }
    }
}