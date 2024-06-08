namespace DAL.Models
{
    public class InstructorCourse
    {
        public int Id{ get; set; }
        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
