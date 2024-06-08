using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Instructor : AppUser
    {
        public string? JobTitle { get; set; }
        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Linkedin { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }

    }
}
