using System.ComponentModel.DataAnnotations;

namespace Bible.DTOs.Queries
{
    public class RegisterQuery
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public String? FirtName { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public String? LastName { get; set; }
        [Required]
        [EmailAddress]
        public String? Email { get; set; }
        [Required]
        public String? Password { get; set; }
        [Required]
        [Compare("Password")]
        public String? ComfirmPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
