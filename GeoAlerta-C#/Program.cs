
using GeoAlerta_C_.Application.Services;
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

            //Adiciona o CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin() // Você pode restringir isso no futuro
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });


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

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<EnderecoService>();
            builder.Services.AddScoped<AlertaService>();



            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Usa o CORS
            app.UseCors("AllowAll");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
