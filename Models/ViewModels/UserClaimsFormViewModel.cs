using InfinitySO.Models.Claims;
using System.Collections.Generic;

namespace InfinitySO.Models.ViewModels
{
    public class UserClaimsFormViewModel
    {
        public UserClaimsFormViewModel()
        {
            Cliams = new List<UserClaim>();
        }
        public string UserId { get; set; }
        public List<UserClaim> Cliams { get; set; }
    }
}
