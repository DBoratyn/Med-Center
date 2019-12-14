using System.ComponentModel.DataAnnotations;

namespace Med_Center_API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 16 characters")]
        public string Password {get; set;}
        [Required]
        public string Role {get; set;}
    }
}