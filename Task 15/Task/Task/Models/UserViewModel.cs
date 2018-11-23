using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name!")]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter last name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter e-mail!")]
        [EmailAddress(ErrorMessage = "Enter correct e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the password!")]
        [MinLength(6, ErrorMessage = "The password must be longer than 6 characters!")]
        [RegularExpression(@"\d+", ErrorMessage = "Password must contain digits!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password!")]
        [Compare("Password", ErrorMessage = "Password must match!")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Enter age!")]
        [Range(18, 99, ErrorMessage = "Age should be from 18 to 99!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter the phone number!")]
        [Phone(ErrorMessage = "Incorrect number")]
        [RegularExpression(@"'+'[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}",
            ErrorMessage = "Enter a number of this type: +nnn-nn-nnn-nn-nn!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter the address!")]
        [MinLength(20, ErrorMessage = "The address must be at least 20 characters long!")]
        public string Address { get; set; }

        public bool IsRegistered { get; set; }
    }
}