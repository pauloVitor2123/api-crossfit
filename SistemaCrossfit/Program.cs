using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<AppDBContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DataBase")
                    )
                );


            builder.Services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            builder.Services.AddScoped<IBaseRepository<Genre>, GenreRepository>();
            builder.Services.AddScoped<IBaseRepository<Student>, StudentRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Seed database
            AppDbInitializer.Seed(app);

            app.Run();

        }
    }
}