using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts;

public class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
{
    public DbSet<Users>? Users { get; set; }
    public DbSet<Tasks>? Tasks { get; set; }
    public DbSet<TaksStatus>? TaskStatus { set; get; }
    public DbSet<TaskUser>? TaskUsers { set; get; }
    public DbSet<Rols>? Rols { set; get; }
    public DbSet<Alimentos>? Alimentos { get; set; }
    public DbSet<Pedidos>? Pedidos { get; set; }
    public DbSet<DetallesPedido>? DetallesPedido { get; set; }


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