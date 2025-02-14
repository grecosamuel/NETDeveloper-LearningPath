using Microsoft.EntityFrameworkCore;

namespace ToDoRazor.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<ToDoRazor.Models.Task>? Tasks { get; set; }
    }
}