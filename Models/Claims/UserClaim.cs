
namespace InfinitySO.Models.Claims
{
    public class UserClaim
    {
        public string ClaimType { get; set; }
        public string ClaimName { get; set; }
        public int ClaimValue { get; set; }
        public bool IsSelected { get; set; }
    }
}
