using Microsoft.AspNetCore.Identity;

namespace Bible.Database.Entities
{
    public class User : IdentityUser<int>
    {
        public String? FirtName { get; set; }
        public String? LastName { get; set; }
        public String? Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastActive { get; set; }
    }
}
