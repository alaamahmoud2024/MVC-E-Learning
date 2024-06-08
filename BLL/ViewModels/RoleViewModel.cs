using System.ComponentModel;

namespace MVC_E_Learning.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [DisplayName("Role")]
        public string Name { get; set; }

        public RoleViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
