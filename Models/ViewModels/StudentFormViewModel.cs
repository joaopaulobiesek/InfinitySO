using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsStudent;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; } //Preciso de um Estudante
        public Address Address { get; set; } //Preciso de um Endereço
        public MainBoard MainBoard { get; set; } //Preciso de um Cadastro Principal
        public ICollection<Student> Students { get; set; }
        public ICollection<Period> Periods { get; set; }
        public ICollection<MainBoard> MainBoards { get; set; }
    }
}