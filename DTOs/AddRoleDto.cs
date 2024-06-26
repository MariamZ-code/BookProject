using System.ComponentModel.DataAnnotations;

namespace BookProject.DTOs
{
    public class AddRoleDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
