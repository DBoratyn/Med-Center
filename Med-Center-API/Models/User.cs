namespace Med_Center_API.Models
{
    public class User
    {
        public int Id {get;set;}
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt {get;set;}
        public string Role { get; set; }
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