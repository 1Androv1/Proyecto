using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using TaskStatus = Models.TaskStatus;

namespace Contexts;

public class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
{
    public DbSet<Users>? Users { get; set; }
    public DbSet<Taks>? Tasks { get; set; }
    public DbSet<TaskStatus>? TaskStatus { set; get; }
    public DbSet<TaskUser>? TaskUsers { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Users
        
        modelBuilder
            .Entity<Taks>()
            .ToTable("Tasks")
            .HasKey(t => t.IdTask);
        
        #endregion
    }
}