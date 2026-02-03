using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Entities.Tables;

namespace TaskManagement.Data.Entities.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
