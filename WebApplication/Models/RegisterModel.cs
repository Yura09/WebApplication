using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class RegisterModel
    {   [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$",
            ErrorMessage = "Minimum 6 Max 20 characters at least 1 Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="password do not match")]
        public string ConfirmPassword { get; set; }
 
        [Required]
        [RegularExpression(@"admin|user", ErrorMessage = "admin or user only allowed")]
        public string Role { get; set; }
    }
}