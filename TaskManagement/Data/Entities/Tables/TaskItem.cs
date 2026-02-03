using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Data.Entities.Tables
{
    [Table("TaskItem")]
    public class TaskItem
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt {  get; set; }
    }
}
