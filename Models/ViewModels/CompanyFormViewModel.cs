using InfinitySO.Models.ModelsAdministration;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class CompanyFormViewModel
    {
        public Company Company { get; set; } //Preciso de uma Empresa
        public Address Address { get; set; } //Preciso de um Endereço
        public ICollection<Company> Companys { get; set; }
    }
}
