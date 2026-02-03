using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Data.Models.Request
{
    public class TaskItemRequest
    {
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        [AllowedValues("Pending", "InProgress", "Completed")]
        public string? Status { get; set; }
        [Required]
        [AllowedValues("Low", "Medium", "High")]
        public string? Priority { get; set; }
    }
}