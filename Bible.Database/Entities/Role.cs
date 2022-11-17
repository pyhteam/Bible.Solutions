using Microsoft.AspNetCore.Identity;

namespace Bible.Database.Entities
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole>? UserRoles { get; set; }

    }
}
