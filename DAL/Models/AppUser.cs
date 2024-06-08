using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class AppUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? ImageName { get; set; }
        public string Discriminator { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
