using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
    }
}
