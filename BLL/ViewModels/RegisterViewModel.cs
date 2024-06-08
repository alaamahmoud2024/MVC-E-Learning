using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class RegisterViewModel
    {
        public string? Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        //public bool? Agree { get; set; }
        public string UserType { get; set; }

    }
}
