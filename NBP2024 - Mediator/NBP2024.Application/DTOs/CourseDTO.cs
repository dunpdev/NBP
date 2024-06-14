using NBP2024.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Application.DTOs
{
    public class CourseDTO
    {
        public CourseDTO()
        {
            Tags = new HashSet<TagDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        public AuthorDTO Author { get; set; }
        public ICollection<TagDTO> Tags { get; set; }
    }
}
