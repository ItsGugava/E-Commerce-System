using System.ComponentModel.DataAnnotations;

namespace E_Commerce_System.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
