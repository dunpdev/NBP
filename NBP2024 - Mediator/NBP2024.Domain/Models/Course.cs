using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NBP2024.Domain.Models
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //[IgnoreDataMember]
        //public string? _id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        [ForeignKey("CoverId")]
        public Cover Cover { get; set; }
        public int CoverId { get; set; }
    }
}
