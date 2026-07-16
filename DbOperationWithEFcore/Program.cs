
using DbOperationWithEFcore.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace DbOperationWithEFcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var x = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Data.appDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddStackExchangeRedisCache(Options =>
                {
                    Options.Configuration = builder.Configuration.GetConnectionString("");
                });
            // Add services to the container.

            builder.Services.AddControllers();
            // Register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();   // Serves the generated OpenAPI/Swagger specification as a JSON endpoint
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseMiddleware<GlobalExceptionHandlingCustomMiddleware>();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
