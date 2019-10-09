using InfinitySO.Models.ModelsAdministration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsPatrimony
{
    public class Patrimony
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Place Place { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Place")]
        [Display(Name = "Referência do Local")]
        public int PlaceId { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Nome do patrimônio")]
        public int ProductId { get; set; }

        [Display(Name = "Chave do patrimônio")]
        public string KeyPatrimony { get; set; }

        [Display(Name = "Numero da Nota Fiscal")]
        public string NoteNumber { get; set; }

        [Display(Name = "Descrição do produto")]
        public string DescriptionProduct { get; set; }

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

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Custo do patrimônio")]
        public double Amount { get; set; }

        [NotMapped]
        public ICollection<Place> Places { get; set; }
        [NotMapped]
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        public ICollection<Patrimony> Patrimonies { get; set; }

        public Patrimony()
        {
        }

        public Patrimony(int id, Place place, Product product, string keyPatrimony, string noteNumber, string descriptionProduct, DateTime dateBuy, DateTime nextMaintenanceDate, double amount)
        {
            Id = id;
            Place = place;
            Product = product;
            KeyPatrimony = keyPatrimony;
            NoteNumber = noteNumber;
            DescriptionProduct = descriptionProduct;
            DateBuy = dateBuy;
            NextMaintenanceDate = nextMaintenanceDate;
            Amount = amount;
        }
    }
}