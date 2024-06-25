using System.ComponentModel.DataAnnotations;

namespace Calendar.ViewModels
{
    public class CreateEventViewModel
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public CreateEventViewModel()
        {
            Name = string.Empty;
            Location = string.Empty;
            Description = string.Empty;
        }
    }
}