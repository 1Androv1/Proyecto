using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts;

public class SqlDbContextLog(DbContextOptions<SqlDbContextLog> options) : DbContext(options)
{
    public DbSet<HttpLog> HttpLogs { get; set; } = null!;
}