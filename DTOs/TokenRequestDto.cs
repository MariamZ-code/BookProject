using System.ComponentModel.DataAnnotations;

namespace BookProject.DTOs
{
    public class TokenRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
