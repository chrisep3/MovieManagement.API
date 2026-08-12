using Microsoft.EntityFrameworkCore;
using MovieManagement.API.Domain;

namespace MovieManagement.API.Infrastructure;

public class AppDbContext : DbContext
{
    //DbContextOptions είναι οι οδηγίες σύνδεσης και λειτουργίας του AppDbContext
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(movie => movie.Id);
            entity.Property(movie => movie.Title).IsRequired().HasMaxLength(200);
            entity.Property(movie => movie.Director).IsRequired().HasMaxLength(100);
            entity.Property(movie => movie.Genre).IsRequired().HasMaxLength(50);
            entity.Property(movie => movie.Rating).HasPrecision(3, 1);

            entity.HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    ReleaseYear = 1994,
                    Genre = "Drama",
                    Rating = 9.3m
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = 1972,
                    Genre = "Crime",
                    Rating = 9.2m
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2008,
                    Genre = "Action",
                    Rating = 9.0m
                },
                new Movie
                {
                    Id = 4,
                    Title = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    ReleaseYear = 1994,
                    Genre = "Crime",
                    Rating = 8.9m
                },
                new Movie
                {
                    Id = 5,
                    Title = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    ReleaseYear = 1994,
                    Genre = "Drama",
                    Rating = 8.8m
                });
        });
    }
}
