
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MiddlewareMVC.Services;
using MiddlewareMVC.Repositories;
using MiddlewareMVC.Loggers;

namespace MiddlewareMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Add services to the container.
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AdventurerDbContext>();

            builder.Services.AddScoped<IAdventurerService,AdventurerService>();
            builder.Services.AddScoped<IAdventurerRepository,AdventurerRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<LoggerMiddleware>();
            builder.Services.AddTransient<ValidateMiddleware>();


            var app = builder.Build();

            app.UseMiddleware<LoggerMiddleware>();
            app.UseMiddleware<ValidateMiddleware>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
