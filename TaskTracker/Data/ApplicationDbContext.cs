using Microsoft.EntityFrameworkCore;
using TaskTracker.Models.Entities;

namespace TaskTracker.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Models.Entities.Task> Tasks { get; set; }
    }
}
