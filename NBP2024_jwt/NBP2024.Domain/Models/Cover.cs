using System.ComponentModel.DataAnnotations.Schema;

namespace NBP2024.Domain.Models
{
    public class Cover
    {
        public int Id { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
