using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfinitySO.Models.ModelsAdministration;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class PatrimonyKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Patrimony Patrimony { get; set; }
        public Sector Sector { get; set; }

        [ForeignKey("Patrimony")]
        [Display(Name = "Nome do Patrimonio")]
        public int PatrimonyId { get; set; }

        [ForeignKey("Sector")]
        [Display(Name = "Setor do patrimônio")]
        public int SectorId { get; set; }
        [Display(Name = "Quantidade do patrimônio")]
        public int Quantity { get; set; }

        [Display(Name = "Chave do patrimônio")]
        public string KeyPatrimony { get; set; }

        [Display(Name = "Endereço de IP")]
        public string IP { get; set; }

        [Display(Name = "Endereço de MAC")]
        public string MAC { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data da compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime DateBuy { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Data da proxima manutenção")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime NextMaintenanceDate { get; set; }

        [Display(Name = "Litros")]
        public double Liter { get; set; }

        [Display(Name = "Kilo Grama")]
        public double KG { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Custo do patrimônio")]
        public double Amount { get; set; }

        [NotMapped]
        public ICollection<Patrimony> Patrimonies { get; set; }
        [NotMapped]
        public ICollection<PatrimonyKey> PatrimonyKeys { get; set; }
        [NotMapped]
        public ICollection<Sector> Sectors { get; set; }

        public PatrimonyKey()
        {
        }

        public PatrimonyKey(int id, Patrimony patrimony, Sector sector, int quantity, string keyPatrimony, string iP, string mAC, DateTime dateBuy, DateTime nextMaintenanceDate, double liter, double kG, double amount)
        {
            Id = id;
            Patrimony = patrimony;
            Sector = sector;
            Quantity = quantity;
            KeyPatrimony = keyPatrimony;
            IP = iP;
            MAC = mAC;
            DateBuy = dateBuy;
            NextMaintenanceDate = nextMaintenanceDate;
            Liter = liter;
            KG = kG;
            Amount = amount;
        }
    }
}