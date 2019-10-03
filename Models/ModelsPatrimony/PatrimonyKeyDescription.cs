using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.Enums;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class PatrimonyKeyDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PatrimonyKey PatrimonyKey { get; set; }
        public LowPatrimony LowPatrimony { get; set; }
        [ForeignKey("PatrimonyKey")]
        [Display(Name = "Quantidade de baixas do patrimônio")]
        public int PatrimonyKeyId { get; set; }

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

        [NotMapped]
        public ICollection<PatrimonyKey> PatrimonyKeys { get; set; }

        public PatrimonyKeyDescription()
        {
        }

        public PatrimonyKeyDescription(int id, PatrimonyKey patrimonyKey, LowPatrimony lowPatrimony, string description, DateTime dateDescription)
        {
            Id = id;
            PatrimonyKey = patrimonyKey;
            LowPatrimony = lowPatrimony;
            Description = description;
            DateDescription = dateDescription;
        }
    }
}