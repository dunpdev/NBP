using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBP2022.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data
{
    public class NBPDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NBPDbContext(DbContextOptions<NBPDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedAuthors
            var Authors = new List<Author>
            {
                new Author{Id=1, Name = "Meris"},
                new Author{Id=2, Name = "Ermin"}
            };
            modelBuilder.Entity<Author>().HasData(Authors);
            #endregion
            #region SeedCourses
            modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Level = 1,
                Name = "Patterns",
                AuthorId = 1,
                Description = "Learning patterns",
                FullPrice = 0
            });

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
