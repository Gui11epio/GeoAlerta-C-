
using GeoAlerta_C_.Infrastructure.Context;
using GeoAlerta_C_.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeoAlerta_C_
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

            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CONEXAO_GS");
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new Exception("A variável de ambiente CONEXAO_GS não está definida.");

                options.UseOracle(connectionString);
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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

            app.Run();
        }
    }
}
