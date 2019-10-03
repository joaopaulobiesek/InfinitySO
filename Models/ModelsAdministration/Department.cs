using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsAdministration
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        public ICollection<Sector> Sectors { get; set; } = new List<Sector>();


        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public IEnumerable<Sector> SelectSector(int id)
        {
            return Sectors.Where(x => x.DepartmentId == id);
        }
    }
}