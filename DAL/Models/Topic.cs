using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Course>? Courses { get; set; }

    }
}
