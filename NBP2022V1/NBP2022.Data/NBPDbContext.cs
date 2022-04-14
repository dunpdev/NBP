using Microsoft.EntityFrameworkCore;
using NBP2022.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data
{
    public class NBPDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NBPDbContext(DbContextOptions<NBPDbContext> options) : base(options)
        {

        }
    }
}
