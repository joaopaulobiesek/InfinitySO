using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsEmployee
{
    public class ScaleFormatting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Journey Journey { get; set; }
        public Scale Scale { get; set; }
        [ForeignKey("Journey")]
        public int JourneyId { get; set; }
        [ForeignKey("Scale")]
        public int ScaleId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Dia da semana")]
        public DayOfWeek Week { get; set; }

        public ScaleFormatting()
        {
        }

        public ScaleFormatting(int id, Journey journey, Scale scale, DayOfWeek week)
        {
            Id = id;
            Journey = journey;
            Scale = scale;
            Week = week;
        }
    }
}
