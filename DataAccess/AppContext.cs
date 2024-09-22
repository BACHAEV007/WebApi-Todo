using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options: options)
{
    public DbSet<Note> Notes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}