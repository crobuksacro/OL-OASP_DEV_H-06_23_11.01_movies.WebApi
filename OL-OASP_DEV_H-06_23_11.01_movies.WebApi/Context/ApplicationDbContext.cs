using Microsoft.EntityFrameworkCore;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Models.Dbo;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        

    }
}
