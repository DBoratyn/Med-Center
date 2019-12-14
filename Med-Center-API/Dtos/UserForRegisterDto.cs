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
        public string Profession {get;set;}
        public string Pesel {get;set;}
        public string Name {get;set;}
        public string SecondName {get;set;}
        public string Surname {get;set;}
        public string DateOfBirth {get;set;}
        public string PlaceOfBirth {get;set;}
        public string City {get;set;}
        public string Street {get;set;}
        public string HouseNumber {get;set;}
        public string ZipCode {get;set;}
    }
}