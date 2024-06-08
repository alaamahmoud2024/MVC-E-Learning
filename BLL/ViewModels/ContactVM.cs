using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class ContactVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
