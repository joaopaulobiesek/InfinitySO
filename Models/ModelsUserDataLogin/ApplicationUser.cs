using InfinitySO.Models.ModelsAdministration;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinitySO.Models.ModelsUserDataLogin
{
    public class ApplicationUser : IdentityUser
    {
        public MainBoard MainBoard { get; set; }
        [ForeignKey("MainBoard")]
        public int MainBoardId { get; set; }
        [NotMapped]
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}