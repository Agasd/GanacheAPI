using System.ComponentModel.DataAnnotations;

namespace Ganache.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(500, MinimumLength =4, ErrorMessage = "The minimum password length is 4 characters")]
        public string Password { get; set; }
    }
}