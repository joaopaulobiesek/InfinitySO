using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsStudent;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class StudentFinancialFormViewModel
    {
        public StudentFinancial StudentFinancial { get; set; }
        public Student Student { get; set; }
        public BilletValue BilletValue { get; set; }
        public MainBoard MainBoard { get; set; }
        public string stringBilletValues { get; set; }
        public List<BilletValue> BilletValues { get; set; }
        public ICollection<MainBoard> MainBoards { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentFinancial> StudentFinancials { get; set; }
    }
}