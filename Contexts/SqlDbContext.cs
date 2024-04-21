using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts;

public class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
{
    public DbSet<Users>? Users { get; set; }
    public DbSet<Tasks>? Tasks { get; set; }
    public DbSet<TaksStatus>? TaskStatus { set; get; }
    public DbSet<TaskUser>? TaskUsers { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Users
        
        modelBuilder
            .Entity<Tasks>()
            .ToTable("Tasks")
            .HasKey(t => t.IdTask);
        
        #endregion
    }
}