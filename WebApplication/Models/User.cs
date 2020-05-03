using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key] public int user_id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 3)]
        public string first_name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 3)]
        public string last_name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Required]
        //    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$",
            ErrorMessage = "Minimum 6 Max 20 characters at least 1 Alphabet, 1 Number and 1 Special Character")]
        public string password { get; set; }

        [Required]
        [RegularExpression(@"admin|user|creator", ErrorMessage = "admin or user only allowed")]
        public string role { get; set; }
        [Required]
        public bool active { get; set; }
     

        public User()
        {
          
        }

        public User(int userId, string firstName, string lastName, string email, string password, string role,bool active)
        {
           this.user_id = userId;
           this.first_name = firstName;
           this.last_name = lastName;
            this.email = email;
            this.password = password;
            this.role = role;
            this.active = active;
        }
    }
}