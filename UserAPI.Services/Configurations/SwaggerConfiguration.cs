using Microsoft.OpenApi.Models;
using System.Reflection;

namespace UserAPI.Services.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            //habilitando a documentação do swagger
            builder.Services.AddEndpointsApiExplorer();

            //personalizando a documentação
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para controle de usuários - Ruan Oliveira",
                    Description = "Projeto desenvolvido em Asp.Net API, DDD, EF Core, AutoMapper e XUnit",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Ruan Oliveira",
                        Email = "ruanoliveira.pro@gmail.com",
                        Url = new Uri("https://www.instagram.com/eu.ruanoliveira?igsh=aWg4ZXBkMnl6MGxn")
                    }
                });
            });

        }
    }
}
