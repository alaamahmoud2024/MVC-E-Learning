using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
