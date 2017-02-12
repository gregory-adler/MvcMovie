using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Places",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Movie",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "People",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Film",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "Robust Movie Name",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Art",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "OK",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Cool",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}