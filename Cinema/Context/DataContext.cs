using Cinema.Models;
namespace Cinema.Context;

using Microsoft.EntityFrameworkCore;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Movie>? Movie { get; set; }
    public DbSet<ShowTime>? ShowTime { get; set; }
    public DbSet<Tickets>? Tickets { get; set; }
}