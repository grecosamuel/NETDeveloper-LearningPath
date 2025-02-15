using Microsoft.EntityFrameworkCore;
using BlogBlazor.Models;

namespace BlogBlazor.Data
{

    public class BlogBlazorDbContext : DbContext
    {
        public BlogBlazorDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}