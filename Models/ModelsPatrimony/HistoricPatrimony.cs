using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.Enums;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class HistoricPatrimony
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Patrimony Patrimony { get; set; }
        public LowPatrimony LowPatrimony { get; set; }
        [ForeignKey("Patrimony")]
        [Display(Name = "Quantidade de baixas do patrimônio")]
        public int PatrimonyId { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Quantidade de baixas do patrimônio")]
        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data da descrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime DateDescription { get; set; }

        public HistoricPatrimony()
        {
        }

        public HistoricPatrimony(int id, Patrimony patrimony, LowPatrimony lowPatrimony, string description, DateTime dateDescription)
        {
            Id = id;
            Patrimony = patrimony;
            LowPatrimony = lowPatrimony;
            Description = description;
            DateDescription = dateDescription;
        }
    }
}
