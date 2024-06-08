using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class CourseVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }
        public string OverView { get; set; }
        public double Duration { get; set; }
        public int Lessons { get; set; }
        public string Videos { get; set; }
        public string Language { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

    }
}
