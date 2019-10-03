using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsSystem
{
    public class SystemController
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameController { get; set; }
        public string NameClaim { get; set; }
        public int ValueClaim { get; set; }
        public bool IsCheck { get; set; }

        public SystemController()
        {
        }

        public SystemController(int id, string name, string nameController, string nameClaim, int valueClaim, bool isCheck)
        {
            Id = id;
            Name = name;
            NameController = nameController;
            NameClaim = nameClaim;
            ValueClaim = valueClaim;
            IsCheck = isCheck;
        }
    }
}