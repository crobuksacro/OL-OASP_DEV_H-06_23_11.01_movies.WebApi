
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Context;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Mapping;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Implementations;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IMoviesService, MoviesService>();


            ///FLUENT VALIDATION 
            builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Transient);

            var app = builder.Build();





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseCors(builder =>
            {
                builder
                   .WithOrigins("http://localhost:4200", "https://localhost:4200", "https://algebra.com")
                   .SetIsOriginAllowedToAllowWildcardSubdomains()
                   .AllowAnyHeader()
                   .WithExposedHeaders("Content-Disposition")
                   .AllowCredentials()
                   .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                   .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            }
        );




            app.MapControllers();

            app.Run();
        }
    }
}
