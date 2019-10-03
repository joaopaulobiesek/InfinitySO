using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsSystem
{
    public class SystemSubController
    {
        public int Id { get; set; }
        public SystemController SystemController { get; set; }
        public int SystemControllerId { get; set; }
        public string Name { get; set; }
        public string NameSubController { get; set; }
        public string NameClaim { get; set; }
        public int ValueClaim { get; set; }
        public bool IsCheck { get; set; }

        public SystemSubController()
        {
        }

        public SystemSubController(int id, SystemController systemController, string name, string nameSubController, string nameClaim, int valueClaim, bool isCheck)
        {
            Id = id;
            SystemController = systemController;
            Name = name;
            NameSubController = nameSubController;
            NameClaim = nameClaim;
            ValueClaim = valueClaim;
            IsCheck = isCheck;
        }
    }
}