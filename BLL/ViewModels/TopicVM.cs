using System.ComponentModel.DataAnnotations;

namespace MVC_E_Learning.ViewModels
{
    public class TopicVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
