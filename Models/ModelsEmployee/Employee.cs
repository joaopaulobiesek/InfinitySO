using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.ModelsAdministration;

namespace InfinitySO.Models.ModelsEmployee
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public MainBoard MainBoard { get; set; }
        public Sector Sector { get; set; }
        public Scale Scale { get; set; }

        [ForeignKey("MainBoard")]
        [Display(Name = "Employee Name")]
        public int MainBoardId { get; set; }

        [ForeignKey("Sector")]
        [Display(Name = "Department Name")]
        public int SectorId { get; set; }

        [ForeignKey("Scale")]
        [Display(Name = "Scale Name")]
        public int ScaleId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Date Admission")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime Admission { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Resignation { get; set; }

        [NotMapped]
        public ICollection<TimePoint> TimePoints { get; set; } = new List<TimePoint>();
        [NotMapped]
        public ICollection<MainBoard> MainBoards { get; set; }
        [NotMapped]
        public ICollection<Sector> Sectors { get; set; }
        [NotMapped]
        public ICollection<Scale> Scales { get; set; }

        public Employee()
        {
        }

        public Employee(int id, MainBoard mainBoard, Sector sector, Scale scale, DateTime admission, DateTime resignation)
        {
            Id = id;
            MainBoard = mainBoard;
            Sector = sector;
            Scale = scale;
            Admission = admission;
            Resignation = resignation;
        }

        public IEnumerable<TimePoint> SelectDateTime(DateTime initial, DateTime final)
        {
            return TimePoints.Where(sr => sr.DateDay >= initial && sr.DateDay <= final);
        }
    }
}