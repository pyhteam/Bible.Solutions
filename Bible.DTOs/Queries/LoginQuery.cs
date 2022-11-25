using System.ComponentModel.DataAnnotations;

namespace Bible.DTOs.Queries
{
    public class LoginQuery
    {
        [Required]
        public String? Email { get; set; }
        [Required]
        public String? Password { get; set; }
    }
}
