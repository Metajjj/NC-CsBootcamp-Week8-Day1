
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

            var conStr = $"Server={Secret.s};Database=AdventurersDb;User Id={Secret.u};Password={Secret.p};Trust Server Certificate=True";
            builder.Services.AddDbContext<AdventurerDbContext>(o => o.UseSqlServer(conStr));
            builder.Services.AddScoped<IAdventurerService,AdventurerService>();
            builder.Services.AddScoped<IAdventurerRepository,AdventurerRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<LoggerMiddleware>();


            var app = builder.Build();

            app.UseMiddleware<LoggerMiddleware>();


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
