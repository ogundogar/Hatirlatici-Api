using Microsoft.AspNetCore.Identity;

namespace HatirlaticiAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime? BirthDay { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
