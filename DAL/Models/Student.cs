using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Student : AppUser
    {
        public string? Grade { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
