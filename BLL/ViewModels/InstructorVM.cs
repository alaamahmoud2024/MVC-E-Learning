using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class InstructorVM
    {
        public string? Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Linkedin { get; set; }
        public string? JobTitle { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }


        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
