using System.Reflection.Metadata.Ecma335;

namespace DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OverView { get; set; }
        public double Duration { get; set; }
        public int Lessons { get; set; }
        public string Videos { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        //public ICollection<Assignment> Assignment { get; set; }


    }
}
