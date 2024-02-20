using Microsoft.EntityFrameworkCore;
using MoviesService.Models;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

}
