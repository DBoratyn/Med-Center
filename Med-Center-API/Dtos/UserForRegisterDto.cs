using System.ComponentModel.DataAnnotations;

namespace Med_Center_API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 10 characters")]
        public string Password {get; set;}
    }
}