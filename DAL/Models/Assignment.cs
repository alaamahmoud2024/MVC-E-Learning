namespace DAL.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
