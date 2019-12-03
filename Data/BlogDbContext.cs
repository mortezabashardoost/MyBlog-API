using Microsoft.EntityFrameworkCore;
using MyBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }
    }
}
