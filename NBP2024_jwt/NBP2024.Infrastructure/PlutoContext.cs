using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBP2024.Domain.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Infrastructure
{
    public class PlutoContext : IdentityDbContext<IdentityUser>
    {
        public PlutoContext(DbContextOptions<PlutoContext> options) : base(options)
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(c => c.Cover).WithOne(c => c.Course).HasForeignKey<Course>(c => c.CoverId);
            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag {Id = 1, Name = "c#"}},
                {"angularjs", new Tag {Id = 2, Name = "angularjs"}},
                {"javascript", new Tag {Id = 3, Name = "javascript"}},
                {"nodejs", new Tag {Id = 4, Name = "nodejs"}},
                {"oop", new Tag {Id = 5, Name = "oop"}},
                {"linq", new Tag {Id = 6, Name = "linq"}},
            };
            modelBuilder.Entity<Tag>().HasData(tags.Values);
            modelBuilder.Entity<Cover>().HasData(
                new List<Cover>
                {
                    new Cover { Id = 1 },
                    new Cover { Id = 2 },
                    new Cover { Id = 3 },
                    new Cover { Id = 4 },
                    new Cover { Id = 5 },
                    new Cover { Id = 6 },
                    new Cover { Id = 7 },
                    new Cover { Id = 8 },
                    new Cover { Id = 9 }
                });
            var authors = new List<Author>
            {
                new Author
                {   Id = 1,
                    Name = "Mosh Hamedani"    },
                new Author
                {   Id = 2,
                    Name = "Anthony Alicea"   },
                new Author
                {   Id = 3,
                    Name = "Eric Wise"  },
                new Author
                {   Id = 4,
                    Name = "Tom Owsiak"   },
                new Author
                {   Id = 5,
                    Name = "John Smith"    }
            };
            modelBuilder.Entity<Author>().HasData(authors);
            var courses = new List<Course>
            {       new Course
                {   
                CoverId = 1,
                Id = 1,
                    Name = "C# Basics",
                    AuthorId = 1,
                    
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = 1,
                    //Tags = new Collection<Tag>()
                    //{    tags["c#"]    }
               },
                new Course
                {   
                    Id = 2,
                    CoverId = 2,
                    Name = "C# Intermediate",
                    AuthorId = 1,
                    
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = 2,
                    //Tags = new Collection<Tag>()
                    //{   tags["c#"],
                    //    tags["oop"]    }
                }
                ,
                new Course
                {   
                    Id = 3,
                    CoverId = 3,
                    Name = "C# Advanced",
                    AuthorId = 1,
                    
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = 3,
                    //Tags = new Collection<Tag>()
                    //{    tags["c#"]     }
                },
                new Course
                {   
                    Id = 4,
                    CoverId = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    AuthorId = 2,
                    
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = 2,
                    //Tags = new Collection<Tag>()
                    //{     tags["javascript"]      }
                },
                new Course
                {   
                    Id = 5,
                    CoverId = 5,
                    Name = "Learn and Understand AngularJS",
                    AuthorId = 2,
                    
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = 2,
                    //Tags = new Collection<Tag>()
                    //{     tags["angularjs"]     }
                },
                new Course
                {   
                    Id = 6,
                    CoverId = 6,
                    Name = "Learn and Understand NodeJS",
                    AuthorId = 2,
                    
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = 2,
                    //Tags = new Collection<Tag>()
                    //{    tags["nodejs"]   }
                },
new Course
                {
                    
    Id = 7,
    CoverId = 7,
                    Name = "Programming for Complete Beginners",
                    AuthorId = 3,
                    
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = 1,
                    //Tags = new Collection<Tag>()
                    //{
                    //    tags["c#"]
                    //}
                },
                new Course
                {
                    
                    Id = 8,
                    CoverId = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    AuthorId = 4,
                    
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = 1,
//Tags = new Collection<Tag>()
//                    {
//                        tags["c#"]
//                    }
                },
                new Course
                {   
                    Id = 9,
                    CoverId = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    AuthorId = 4,
                    
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = 1,
                    //Tags = new Collection<Tag>()
                    //{
                    //    tags["javascript"]
                    //}
                }
            };
            modelBuilder.Entity<Course>().HasData(courses);

            base.OnModelCreating(modelBuilder);
        }
    }
}
