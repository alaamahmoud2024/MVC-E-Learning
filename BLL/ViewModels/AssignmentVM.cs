using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace BL.ViewModels
{
    public class AssignmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int IdForCourse { get; set; }
        public Course Course { get; set; }
        public IFormFile Assignment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
