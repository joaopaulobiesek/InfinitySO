using InfinitySO.Models.Enums;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsSystem;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsUserDataLogin
{
    public class UserDataLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public MainBoard MainBoard { get; set; }
        [ForeignKey("MainBoard")]
        public int MainBoardId { get; set; }

        //[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordUser { get; set; }

        [NotMapped]
        public ICollection<MainBoard> MainBoards { get; set; }
        [NotMapped]
        public List<SystemController> SystemControllers { get; set; }
        [NotMapped]
        public List<SystemSubController> SystemSubControllers { get; set; }

        public UserDataLogin()
        {
        }

        public UserDataLogin(int id, MainBoard mainBoard, string userName, string passwordUser)
        {
            Id = id;
            MainBoard = mainBoard;
            UserName = userName;
            PasswordUser = passwordUser;
        }
    }
}