using System.ComponentModel.DataAnnotations;

namespace Calendar.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string UserName { get; set; }
    }
}